using Cassandra;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        private ISession session;
        private List<NguoiDungDTO> dsNguoiDung = new List<NguoiDungDTO>();
        public frmNhanVien()
        {
            InitializeComponent();
            khoiTaoKetNoi();
        }
        // Khởi tạo kết nối với Cassandra
        private void khoiTaoKetNoi()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("localhost")
                .Build();
            session = cluster.Connect("qlgiaotan");
        }
        private List<NguoiDungDTO> LayDanhSachNguoiDung()
        {
            List<NguoiDungDTO> nguoiDungs = new List<NguoiDungDTO>();
            var result = session.Execute("SELECT tendangnhap,matkhau,vaitro from nguoidung");

            foreach (var item in result)
            {
                nguoiDungs.Add(new NguoiDungDTO
                {
                    tenDangNhap = item.GetValue<string>("tendangnhap"),
                    matKhau = item.GetValue<string>("matkhau"),
                    vaiTro = item.GetValue<string>("vaitro")
                });
            }
            return nguoiDungs;
        }
        private void HienThiMonAn(List<NguoiDungDTO> dsMonAn)
        {
            if (dsMonAn.Count > 0)
            {
                dgvNhanVien.DataSource = dsMonAn;
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dsNguoiDung = LayDanhSachNguoiDung();
            // Đặt tên cho các cột
            dgvNhanVien.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Tạo các cột thủ công và đặt tên hiển thị
            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                Name = "TenDangNhap"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MatKhau",
                HeaderText = "Mật khẩu",
                Name = "MatKhau"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VaiTro",
                HeaderText = "Role",
                Name = "VaiTro"
            });
            HienThiMonAn(dsNguoiDung);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ dòng hiện tại
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];


                string tenDangNhap = row.Cells["TenDangNhap"].Value.ToString();
                string matKhau = row.Cells["MatKhau"].Value.ToString();
                string vaiTro = row.Cells["VaiTro"].Value.ToString();

                capNhatNguoiDung(tenDangNhap, matKhau, vaiTro);

                dsNguoiDung = LayDanhSachNguoiDung();
                HienThiMonAn(dsNguoiDung);
            }
            else
            {
                MessageBox.Show("Chọn nhân viên muốn cập nhật", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void capNhatNguoiDung(string? tenDangNhap, string? matKhau, string? vaiTro)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);
            string updateQuery = "UPDATE nguoidung SET matkhau = ?, vaitro = ? WHERE tendangnhap = ?";

            var preparedStatement = session.Prepare(updateQuery);
            var boundStatement = preparedStatement.Bind(hashedPassword, vaiTro, tenDangNhap);

            session.Execute(boundStatement);

            MessageBox.Show("Cập nhật thành công!", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                string tenDangNhap = row.Cells["TenDangNhap"].Value.ToString();
                xoaNguoiDung(tenDangNhap);
                dsNguoiDung = LayDanhSachNguoiDung();
                HienThiMonAn(dsNguoiDung);
            }
            else
            {
                MessageBox.Show("Chọn nhân viên muốn xóa", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xoaNguoiDung(string? tenDangNhap)
        {
            string deleteQuery = "DELETE FROM nguoidung WHERE tendangnhap = ?";

            var preparedStatement = session.Prepare(deleteQuery);
            var boundStatement = preparedStatement.Bind(tenDangNhap);

            session.Execute(boundStatement);

            MessageBox.Show("Xóa thành công!", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
