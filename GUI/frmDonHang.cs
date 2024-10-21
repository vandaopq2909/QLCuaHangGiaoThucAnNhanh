using Cassandra;
using Cassandra.DataStax.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GUI
{
    public partial class frmDonHang : Form
    {
        public Cluster cluster;
        public ISession session;
        public string maMA;
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

                session = cluster.Connect("qlgiaotan");


                loadDSKhachHang();
                loadDSMonAn();
                loadDSDonHang();
                data_binding();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!");
            }

        }

        private void loadDSMonAn()
        {
            DataTable dtMonAn = new DataTable();
            dtMonAn.Columns.Add("Tên Món Ăn", typeof(string));
            dtMonAn.Columns.Add("Loại Món Ăn", typeof(string));
            dtMonAn.Columns.Add("Đơn Giá", typeof(double));

            var rs = session.Execute("SELECT * FROM monan");


            foreach (var row in rs)
            {
                DataRow dr = dtMonAn.NewRow();
                dr["Tên Món Ăn"] = row.GetValue<string>("tenmon");
                dr["Loại Món Ăn"] = row.GetValue<string>("tenloai");
                dr["Đơn Giá"] = row.GetValue<double>("gia");

                dtMonAn.Rows.Add(dr);
            }

            dgvDSMonAn.DataSource = dtMonAn;
        }

        private void data_binding()
        {
            cboKH.DataBindings.Clear();
            cboKH.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Tên Khách Hàng");

            txtMaDH.DataBindings.Clear();
            txtMaDH.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Mã Đơn Hàng");

            dtpNgayDat.DataBindings.Clear();
            dtpNgayDat.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Ngày Đặt");

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Tổng Tiền");

            txtPTTT.DataBindings.Clear();
            txtPTTT.DataBindings.Add("TEXT", dgvDonHang.DataSource, "PT Thanh Toán");

            txtTrangThai.DataBindings.Clear();
            txtTrangThai.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Trạng Thái");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("TEXT", dgvDonHang.DataSource, "Địa Chỉ");
        }

        private void loadDSKhachHang()
        {
            // Tạo DataTable để chứa dữ liệu khách hàng
            DataTable dtKhachHang = new DataTable();
            dtKhachHang.Columns.Add("makh", typeof(string));
            dtKhachHang.Columns.Add("tenkh", typeof(string));

            var rs = session.Execute("SELECT * FROM khachhang");


            foreach (var row in rs)
            {
                dtKhachHang.Rows.Add(row.GetValue<string>("makh"), row.GetValue<string>("tenkh"));
            }

            // Gán danh sách vào ComboBox
            cboKH.DataSource = dtKhachHang;
            cboKH.DisplayMember = "tenkh";  // Thuộc tính hiển thị là tên khách hàng
            cboKH.ValueMember = "makh";
        }

        private void loadDSDonHang()
        {
            // Truy vấn để lấy danh sách sinh viên
            var rs = session.Execute("SELECT madh, makh, ngaydat, tongtien, ptthanhtoan, trangthai, diachi FROM donhang");

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Đơn Hàng", typeof(string));
            dt.Columns.Add("Tên Khách Hàng", typeof(string));
            dt.Columns.Add("Ngày Đặt", typeof(DateTime));
            dt.Columns.Add("Tổng Tiền", typeof(string));
            dt.Columns.Add("PT Thanh Toán", typeof(string));
            dt.Columns.Add("Trạng Thái", typeof(string));
            dt.Columns.Add("Địa Chỉ", typeof(string));

            // Duyệt qua các hàng dữ liệu trả về
            foreach (var row in rs)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Đơn Hàng"] = row.GetValue<string>("madh");
                dr["Tên Khách Hàng"] = layTenKHBangMaKH(row.GetValue<string>("makh"));
                dr["Ngày Đặt"] = row.GetValue<DateTime>("ngaydat").ToShortDateString();
                dr["Tổng Tiền"] = row.GetValue<double>("tongtien");
                dr["PT Thanh Toán"] = row.GetValue<string>("ptthanhtoan");
                dr["Trạng Thái"] = row.GetValue<string>("trangthai");
                dr["Địa Chỉ"] = row.GetValue<string>("diachi");
                dt.Rows.Add(dr);
            }

            dgvDonHang.DataSource = dt;
        }

        private string layTenKHBangMaKH(string makh)
        {
            // Truy vấn tìm kiếm tên khách hàng dựa trên mã khách hàng
            string query = "SELECT tenkh FROM khachhang WHERE makh = ?";
            var preparedStatement = session.Prepare(query);
            var boundStatement = preparedStatement.Bind(makh);

            var rs = session.Execute(boundStatement);

            // Lấy ra giá trị tên khách hàng từ kết quả truy vấn
            var row = rs.FirstOrDefault();
            if (row != null)
            {
                return row.GetValue<string>("tenkh");
            }
            else
            {
                return "null";
            }
        }
        private string layMaKHBangTenKH(string tenkh)
        {
            string query = "SELECT makh FROM khachhang WHERE tenkh = ? ALLOW FILTERING";

            var preparedStatement = session.Prepare(query);
            var boundStatement = preparedStatement.Bind(tenkh);

            var rs = session.Execute(boundStatement);

            // Lấy kết quả từ hàng đầu tiên nếu có
            var row = rs.FirstOrDefault();
            if (row != null)
            {
                return row["makh"].ToString();
            }
            else
            {
                return "null";
            }
        }

        private void btnThemDH_Click(object sender, EventArgs e)
        {
            txtMaDH.Clear();
            dtpNgayDat.Value = DateTime.Now;
            txtTongTien.Text = "0";
            txtPTTT.Clear();
            txtTrangThai.Clear();
            txtDiaChi.Clear();

            txtMaDH.Focus();

            btnLuu.Enabled = true;
        }

        private bool KTTrungMaDH(string madh)
        {
            bool isTrung = false;
            try
            {
                string query = "SELECT count(*) FROM donhang WHERE madh = ? ALLOW FILTERING";

                var preparedStatement = session.Prepare(query);
                var boundStatement = preparedStatement.Bind(madh);

                var rs = session.Execute(boundStatement);

                // Lấy giá trị COUNT từ hàng đầu tiên của kết quả
                int count = rs.First().GetValue<int>("count");

                // Nếu tìm thấy mã đơn hàng, tức là mã đã tồn tại
                if (count > 0)
                {
                    isTrung = true;
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra trùng thất bại!");
            }
            return isTrung;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã Đơn Hàng!");
                txtMaDH.Focus();
                return;
            }

            if (dtpNgayDat.Value > DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn Ngày Đặt hợp lệ!");
                dtpNgayDat.Focus();
                return;
            }          

            if (txtPTTT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập PT Thanh Toán!");
                txtPTTT.Focus();
                return;
            }

            if (txtTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Trạng Thái!");
                txtTrangThai.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Địa Chỉ!");
                txtDiaChi.Focus();
                return;
            }

            //if (KTTrungMaDH(txtMaDH.Text.Trim()))
            //{
            //    MessageBox.Show("Mã Đơn Hàng đã tồn tại!");
            //    txtMaDH.Focus();
            //    return;
            //}

            try
            {
                string query = "INSERT INTO donhang (makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai, diachi) VALUES (?, ?, ?, ?, ?, ?, ?)";

                var preparedStatement = session.Prepare(query);

                string makh = cboKH.SelectedValue.ToString();
                string madh = txtMaDH.Text;
                double tongtien = double.Parse(txtTongTien.Text);
                DateTime ngaydat = dtpNgayDat.Value;
                string ptthanhtoan = txtPTTT.Text;
                string trangthai = txtTrangThai.Text;
                string diachi = txtDiaChi.Text;

                var boundStatement = preparedStatement.Bind(makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai, diachi);

                session.Execute(boundStatement);

                updatePTTTCuaKHBangMaKH(makh);
                MessageBox.Show("Thêm đơn hàng thành công!");
                btnLuu.Enabled = false;
                loadDSDonHang();
                data_binding();
            }
            catch
            {
                MessageBox.Show("Thêm đơn hàng thất bại!");
            }
        }

        private void updatePTTTCuaKHBangMaKH(string? makh)
        {
            try
            {
                // Cập nhật phương thức thanh toán
                string updateQuery = "UPDATE ttkhtheopttt SET ptthanhtoan = ? WHERE makh = ?";
                var updateStatement = session.Prepare(updateQuery);
                var boundUpdateStatement = updateStatement.Bind(txtPTTT.Text.Trim(), makh);
                session.Execute(boundUpdateStatement);
            }
            catch (Exception ex) { 
                MessageBox.Show("Lỗi cập nhật phương thức thanh toán: " + ex.Message);
            }
        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn hàng " + txtMaDH.Text + " ?", "Xóa", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            try
            {
                //xóa đơn hàng
                string query = "DELETE FROM donhang WHERE madh = ? AND makh = ? AND tongtien = ?";

                var preparedStatement = session.Prepare(query);

                string madh = txtMaDH.Text;
                string makh = cboKH.SelectedValue.ToString();
                double tongtien = double.Parse(txtTongTien.Text);
                var boundStatement = preparedStatement.Bind(madh, makh, tongtien);

                session.Execute(boundStatement);

                //xóa tất cả chi tiết đơn hàng theo madh đã xóa
                string query2 = "DELETE FROM ctdonhang WHERE madh = ?";

                var preparedStatement2 = session.Prepare(query2);

                var boundStatement2 = preparedStatement2.Bind(madh);
                session.Execute(boundStatement2);

                MessageBox.Show("Xóa đơn hàng thành công!");
                loadDSDonHang();
                data_binding();
            }
            catch
            {
                MessageBox.Show("Xóa đơn hàng thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDSMonAn();
            loadDSDonHang();
            data_binding();
        }
        string premadh, premakh;
        double pretongtien;
        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần sửa!");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn sửa đơn hàng " + txtMaDH.Text + " ?", "Xóa", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            try
            {
                //xóa đơn hàng cũ
                string deleteQuery = "DELETE FROM donhang WHERE madh = ? AND makh = ? AND tongtien = ?";

                var deletePreparedStatement = session.Prepare(deleteQuery);
                var deleteBoundStatement = deletePreparedStatement.Bind(premadh, premakh, pretongtien);

                session.Execute(deleteBoundStatement);

                //thêm đơn hàng mới để cập nhật các giá trị
                string query = "INSERT INTO donhang (makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai, diachi) VALUES (?, ?, ?, ?, ?, ?, ?)";

                var preparedStatement = session.Prepare(query);

                string makh = cboKH.SelectedValue.ToString();
                string madh = txtMaDH.Text;
                double tongtien = double.Parse(txtTongTien.Text);
                DateTime ngaydat = dtpNgayDat.Value;
                string ptthanhtoan = txtPTTT.Text;
                string trangthai = txtTrangThai.Text;
                string diachi = txtDiaChi.Text;

                var boundStatement = preparedStatement.Bind(makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai, diachi);

                session.Execute(boundStatement);

                updatePTTTCuaKHBangMaKH(makh);
                MessageBox.Show("Đã cập nhật đơn hàng thành công!");
                loadDSDonHang();
                data_binding();
            }
            catch
            {
                MessageBox.Show("Cập nhật đơn hàng thất bại!");
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ dòng hiện tại
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];

                string tenkh = row.Cells["Tên Khách Hàng"].Value.ToString();
                premadh = row.Cells["Mã Đơn Hàng"].Value.ToString();
                premakh = layMaKHBangTenKH(tenkh);
                pretongtien = Convert.ToDouble(row.Cells["Tổng Tiền"].Value);

                string maDH = txtMaDH.Text;
                loadDSCTDonHangTheoMaDH(maDH);
            }
        }

        private void loadDSCTDonHangTheoMaDH(string maDH)
        {
            try
            {
                // Truy vấn để lấy danh sách sinh viên
                var query = "SELECT * FROM ctdonhang WHERE madh = ? ALLOW FILTERING";
                var PreparedStatement = session.Prepare(query);
                var BoundStatement = PreparedStatement.Bind(maDH);

                var rs = session.Execute(BoundStatement);

                // Tạo DataTable để chứa dữ liệu
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Đơn Hàng", typeof(string));
                dt.Columns.Add("Mã Món Ăn", typeof(string));
                dt.Columns.Add("Tên Món Ăn", typeof(string));
                dt.Columns.Add("Số Lượng", typeof(int));
                dt.Columns.Add("Tổng Tiền", typeof(string));

                // Duyệt qua các hàng dữ liệu trả về
                foreach (var row in rs)
                {
                    DataRow dr = dt.NewRow();
                    dr["Mã Đơn Hàng"] = row.GetValue<string>("madh");
                    dr["Mã Món Ăn"] = row.GetValue<string>("mamonan");
                    dr["Tên Món Ăn"] = row.GetValue<string>("tenmonan");
                    dr["Số Lượng"] = row.GetValue<int>("soluong");
                    dr["Tổng Tiền"] = row.GetValue<double>("tongtien");
                    dt.Rows.Add(dr);
                }

                dgvCTDonHang.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Lỗi tải chi tiết đơn hàng!");
            }
        }

        private void dgvDSMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ dòng hiện tại
                DataGridViewRow row = dgvDSMonAn.Rows[e.RowIndex];

                maMA = layMaMonAnBangTenMonAn(row.Cells["Tên Món Ăn"].Value.ToString());
            }
        }
        private string layMaMonAnBangTenMonAn(string? tenMonAn)
        {
            string maMonAn = "null";
            try
            {
                string query = "SELECT mamonan FROM monan WHERE tenmon = ? ALLOW FILTERING";
                var preparedStatement = session.Prepare(query);
                var boundStatement = preparedStatement.Bind(tenMonAn);

                var rs = session.Execute(boundStatement);

                // Lấy ra giá trị tên khách hàng từ kết quả truy vấn
                var row = rs.FirstOrDefault();
                if (row != null)
                {
                    maMonAn = row.GetValue<string>("mamonan");
                }
            }
            catch
            {
                MessageBox.Show("Lấy Mã Món Ăn thất bại!");
            }
            return maMonAn;
        }

        private void btnThemMAVaoCTDH_Click(object sender, EventArgs e)
        {
            string madh = txtMaDH.Text;
            string mamonan = maMA;
            string tenmonan = "";
            int soluong = 1;
            double tongtien = 0;
            double dongia = 0;
            int soluongHienTai = 0;
            int slmoi = 0;
            try
            {
                string query1 = "SELECT * FROM monan WHERE mamonan = ? ALLOW FILTERING";
                var preparedStatement1 = session.Prepare(query1);
                var boundStatement1 = preparedStatement1.Bind(mamonan);

                var rs = session.Execute(boundStatement1);

                var row = rs.FirstOrDefault();
                if (row != null)
                {
                    tenmonan = row.GetValue<string>("tenmon");
                    dongia = row.GetValue<double>("gia");
                    tongtien = dongia;
                }

                // Câu truy vấn kiểm tra món ăn đã tồn tại hay chưa
                string checkQuery = "SELECT soluong, tongtien FROM ctdonhang WHERE madh = ? AND mamonan = ? ALLOW FILTERING";
                var checkStatement = session.Prepare(checkQuery);
                var boundCheckStatement = checkStatement.Bind(madh, mamonan);
                var checkResult = session.Execute(boundCheckStatement);

                var r = checkResult.FirstOrDefault();
                if (r != null) // Nếu món ăn đã tồn tại
                {
                    // Lấy giá trị hiện tại của soluong              
                    soluongHienTai = r.GetValue<int>("soluong");

                    // Cập nhật số lượng và tổng tiền
                    string updateQuery = "UPDATE ctdonhang SET soluong = ?, tongtien = ? WHERE madh = ? AND mamonan = ?";
                    var updateStatement = session.Prepare(updateQuery);
                    slmoi = soluongHienTai + 1;
                    var boundUpdateStatement = updateStatement.Bind(slmoi, slmoi * dongia, madh, mamonan);
                    session.Execute(boundUpdateStatement);

                    //cập nhật lại số lượng đã đặt của món ăn đó
                    CapNhatSoLuongMonAnKhiThem(maMA, slmoi);
                }
                else // Nếu món ăn chưa tồn tại
                {
                    // Thêm món ăn mới vào ctdonhang
                    string insertQuery = "INSERT INTO ctdonhang (madh, mamonan, soluong, tenmonan, tongtien) VALUES (?, ?, ?, ?, ?)";
                    var insertStatement = session.Prepare(insertQuery);
                    var boundInsertStatement = insertStatement.Bind(madh, mamonan, soluong, tenmonan, tongtien);
                    session.Execute(boundInsertStatement);

                    //cập nhật lại số lượng đã đặt của món ăn đó
                    CapNhatSoLuongMonAnKhiThem(maMA, soluongHienTai + 1);
                }

                MessageBox.Show("Đã cập nhật chi tiết đơn hàng thành công!");
                TinhTongTienDonHang(madh);
                loadDSDonHang();
                loadDSCTDonHangTheoMaDH(madh);
                data_binding();
            }
            catch
            {
                MessageBox.Show("Cập nhật chi tiết đơn hàng thất bại!");
            }
        }

        public void CapNhatSoLuongMonAnKhiThem(string mamonan, int soLuongThayDoi)
        {
            try
            {
                // Lấy số lượng đã đặt hiện tại từ bảng MonAn
                string getSoLuongQuery = "SELECT sldadat, gia FROM monan WHERE mamonan = ? ALLOW FILTERING";
                var getSoLuongStatement = session.Prepare(getSoLuongQuery);
                var boundGetSoLuongStatement = getSoLuongStatement.Bind(mamonan);
                var getSoLuongResult = session.Execute(boundGetSoLuongStatement);

                double gia = 0;
                var row = getSoLuongResult.FirstOrDefault();
                if (row != null)
                {
                    int soluongDaDatHienTai = row.GetValue<int>("sldadat");
                    gia = row.GetValue<double>("gia");

                    // Cập nhật số lượng mới cho món ăn
                    int soluongCapNhat = soluongDaDatHienTai + soLuongThayDoi;  // +1 hoặc -1
                    string updateMonAnQuery = "UPDATE monan SET sldadat = ? WHERE mamonan = ? AND gia = ?";
                    var updateMonAnStatement = session.Prepare(updateMonAnQuery);
                    var boundUpdateMonAnStatement = updateMonAnStatement.Bind(soluongCapNhat, mamonan, gia);
                    session.Execute(boundUpdateMonAnStatement);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số lượng món ăn: " + ex.Message);
            }
        }

        public void TinhTongTienDonHang(string madh)
        {
            try
            {
                // Truy vấn tổng tiền từ bảng ctdonhang
                string sumQuery = "SELECT SUM(tongtien) AS total FROM ctdonhang WHERE madh = ? ALLOW FILTERING";
                var sumStatement = session.Prepare(sumQuery);
                var boundSumStatement = sumStatement.Bind(madh);
                var sumResult = session.Execute(boundSumStatement);

                var row = sumResult.FirstOrDefault();
                if (row != null)
                {
                    double tongTienMoi = row.GetValue<double>("total");  // Lấy tổng tiền mới

                    //xóa đơn hàng cũ
                    string deleteQuery = "DELETE FROM donhang WHERE madh = ? AND makh = ? AND tongtien = ?";

                    var deletePreparedStatement = session.Prepare(deleteQuery);
                    pretongtien = double.Parse(txtTongTien.Text);
                    var deleteBoundStatement = deletePreparedStatement.Bind(premadh, premakh, pretongtien);

                    session.Execute(deleteBoundStatement);

                    //thêm đơn hàng mới để cập nhật các giá trị
                    string query = "INSERT INTO donhang (makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai, diachi) VALUES (?, ?, ?, ?, ?, ?, ?)";

                    var preparedStatement = session.Prepare(query);

                    string makh = cboKH.SelectedValue.ToString();
                    DateTime ngaydat = dtpNgayDat.Value;
                    string ptthanhtoan = txtPTTT.Text;
                    string trangthai = txtTrangThai.Text;
                    string diachi = txtDiaChi.Text;

                    var boundStatement = preparedStatement.Bind(makh, madh, tongTienMoi, ngaydat, ptthanhtoan, trangthai, diachi);

                    session.Execute(boundStatement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lại tổng tiền đơn hàng: " + ex.Message);
            }
        }

        private void btnXoaMAKhoiCTDH_Click(object sender, EventArgs e)
        {
            string mamonan = maMA;
            string madh = txtMaDH.Text;

            if (mamonan == null) {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!");
                return;
            }

            try
            {
                string query = "DELETE FROM ctdonhang  WHERE madh = ? AND mamonan = ?";

                var deletePreparedStatement = session.Prepare(query);
                var deleteBoundStatement = deletePreparedStatement.Bind(madh, maMA);

                session.Execute(deleteBoundStatement);

                CapNhatSoLuongMonAnKhiThem(maMA, -1);

                MessageBox.Show("Xóa Món Ăn thành công!");
                TinhTongTienDonHang(madh);
                loadDSDonHang();
                data_binding();

            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa món ăn khỏi đơn hàng: " + ex.Message);
            }
        }
    }
}
