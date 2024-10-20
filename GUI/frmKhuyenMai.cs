using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cassandra;
using Cassandra.DataStax.Graph;
using GUI.Class;

namespace GUI
{
    public partial class frmKhuyenMai : Form
    {
        private ISession session;

        private void ConnectionCassandra()
        {
            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            session = cluster.Connect("qlgiaotan");
        }

        public bool IsTextEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public frmKhuyenMai()
        {
            InitializeComponent();
            ConnectionCassandra();
            if (session == null)
            {
                throw new InvalidOperationException("Không thể kết nối đến Cassandra.");
            }
            LoadData();
        }

        private void LoadData()
        {
            List<KhuyenMai> listKM = new List<KhuyenMai> ();
            var query = session.Execute("SELECT MaMonAn, TenKM, TenMonAn, TiLe, NgayBD, NgayKT, MoTa FROM KMTheoMonAn");

            foreach (var item in query)
            {
                listKM.Add(new KhuyenMai
                {
                    MaMonAn = item.GetValue<string>("mamonan"),
                    TenKM = item.GetValue<string>("tenkm"),
                    TenMonAn = item.GetValue<string>("tenmonan"),
                    TiLe = item.GetValue<double>("tile"),
                    NgayBD = item.GetValue<DateTime>("ngaybd"),
                    NgayKT = item.GetValue<DateTime>("ngaykt"),
                    MoTa = item.GetValue<string>("mota")
                });
            }

            if (listKM.Count > 0)
            {
                dgvDanhSachKhuyenMai.Rows.Clear();
                foreach (var km in listKM)
                {
                    dgvDanhSachKhuyenMai.Rows.Add(km.MaMonAn, km.TenKM, km.TenMonAn, km.TiLe, km.NgayBD, km.NgayKT, km.MoTa);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemKM_Click(object sender, EventArgs e)
        {
            if (IsTextEmpty(txtMaMonAn.Text) || IsTextEmpty(txtTenKM.Text) || IsTextEmpty(txtTenMonAn.Text) || IsTextEmpty(txtTiLe.Text) || IsTextEmpty(txtMoTa.Text)) 
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm.", "Thông báo");
                return;
            }
            try
            {
                if (dtpNgayKT.Value < dtpNgayBD.Value)
                {
                    MessageBox.Show("Ngày kết thúc phải bằng hoặc sau ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var khuyenMai = new KhuyenMai
                {
                    MaMonAn = txtMaMonAn.Text,
                    TenKM = txtTenKM.Text,
                    TenMonAn = txtTenMonAn.Text,
                    TiLe = double.Parse(txtTiLe.Text),
                    NgayBD = dtpNgayBD.Value,
                    NgayKT = dtpNgayKT.Value,
                    MoTa = txtMoTa.Text
                };

                string insertQuery = "INSERT INTO kmtheomonan (mamonan, tile, ngaybd, ngaykt, mota, tenkm, tenmonan) VALUES (?, ?, ?, ?, ?, ?, ?)";
                var statement = session.Prepare(insertQuery);
                var boundStatement = statement.Bind(khuyenMai.MaMonAn, khuyenMai.TiLe, khuyenMai.NgayBD, khuyenMai.NgayKT, khuyenMai.MoTa, khuyenMai.TenKM, khuyenMai.TenMonAn);

                session.Execute(boundStatement);
                MessageBox.Show("Thêm thông tin thành công!", "Thông báo");

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtMaMonAn.Text = "";
            txtTenKM.Text = "";
            txtTenMonAn.Text = "";
            txtTiLe.Text = "";
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtMoTa.Text = "";
        }

        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maMonAn = txtMaMonAn.Text;

                    if (IsTextEmpty(maMonAn))
                    {
                        MessageBox.Show("Chọn món ăn cần xóa!", "Thông báo");
                        return;
                    }

                    string query = "DELETE FROM kmtheomonan WHERE mamonan = ?";
                    var preparedStatement = session.Prepare(query);
                    var boundStatement = preparedStatement.Bind(maMonAn);

                    session.Execute(boundStatement);

                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này không?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                try
                {
                    if (IsTextEmpty(txtTenKM.Text) || IsTextEmpty(txtTenMonAn.Text) || IsTextEmpty(txtTiLe.Text) || IsTextEmpty(txtMoTa.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm.", "Thông báo");
                        return;
                    }

                    if (dgvDanhSachKhuyenMai.SelectedRows.Count > 0)
                    {
                        if (dtpNgayKT.Value < dtpNgayBD.Value)
                        {
                            MessageBox.Show("Ngày kết thúc phải bằng hoặc sau ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string maMonAn = txtMaMonAn.Text;
                        var tenKM = txtTenKM.Text;
                        var tenMonAn = txtTenMonAn.Text;
                        var tiLe = Double.Parse(txtTiLe.Text);
                        var ngayBD = dtpNgayBD.Value;
                        var ngayKT = dtpNgayKT.Value;
                        var moTa = txtMoTa.Text;

                        string updateQuery = "UPDATE kmtheomonan SET tile = ?, ngaybd = ?, ngaykt = ?, mota = ?, tenkm = ?, tenmonan = ? WHERE mamonan = ?";
                        var statement = session.Prepare(updateQuery);
                        var boundStatement = statement.Bind(tiLe, ngayBD, ngayKT, moTa, tenKM, tenMonAn, maMonAn);
                        session.Execute(boundStatement);

                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");

                        LoadData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một dòng trong bảng Danh Sách Khuyến Mãi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKhuyenMai.SelectedRows.Count > 0)
            {
                btnSuaKM_Click(sender, e);
            }
            else
            {
                btnThemKM_Click(sender, e);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var ngayChon = dtpNgayTimKiem.Value;
            var tenMonAnChon = txtMonAnTimKiem.Text;

            var q5 = session.Prepare("SELECT MaMonAn, TenKM, TenMonAn, TiLe, NgayBD, NgayKT, MoTa " + "FROM KMTheoMonAn" + "WHERE NgayBD <= ? AND NgayKT >= ?");
            var boundStatement_q5 = q5.Bind( ngayChon, ngayChon);

            var result_q5 = session.Execute(boundStatement_q5);

            var q6 = session.Prepare("SELECT MaMonAn, TenKM, TenMonAn, TiLe, NgayBD, NgayKT, MoTa " + "FROM KMTheoMonAn" + "WHERE TenMonAn = ? AND NgayBD <= ? AND NgayKT >= ?");
            var boundStatement_q6 = q6.Bind( tenMonAnChon, ngayChon, ngayChon);

            var result_q6 = session.Execute(boundStatement_q6);

            DisplayResults(result_q5, result_q6);
        }

        private void dgvDanhSachKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                DataGridViewRow selectedRow = dgvDanhSachKhuyenMai.Rows[e.RowIndex];

                txtMaMonAn.Text = selectedRow.Cells["MaMonAn"].Value?.ToString();
                txtTenKM.Text = selectedRow.Cells["TenKM"].Value?.ToString();
                txtTenMonAn.Text = selectedRow.Cells["TenMonAn"].Value?.ToString();
                txtTiLe.Text = selectedRow.Cells["TiLe"].Value?.ToString();
                dtpNgayBD.Value = (DateTime)selectedRow.Cells["NgayBD"].Value;
                dtpNgayKT.Value = (DateTime)selectedRow.Cells["NgayKT"].Value;
                txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
            }
        }

        private void DisplayResults(IEnumerable<Row> q5, IEnumerable<Row> q6)
        {
            dgvDanhSachKhuyenMai.Rows.Clear();

            foreach (var row in q5)
            {
                dgvDanhSachKhuyenMai.Rows.Add(
                    row.GetValue<string>("mamonan"),
                    row.GetValue<string>("tenkm"),
                    row.GetValue<string>("tenmonan"),
                    row.GetValue<double>("tile"),
                    row.GetValue<DateTime>("ngaybd"),
                    row.GetValue<DateTime>("ngaykt"),
                    row.GetValue<string>("mota")
                );
            }

            foreach (var row in q6)
            {
                dgvDanhSachKhuyenMai.Rows.Add(
                    row.GetValue<string>("mamonan"),
                    row.GetValue<string>("tenkm"),
                    row.GetValue<string>("tenmonan"),
                    row.GetValue<double>("tile"),
                    row.GetValue<DateTime>("ngaybd"),
                    row.GetValue<DateTime>("ngaykt"),
                    row.GetValue<string>("mota")
                );
            }
        }
    }
}
