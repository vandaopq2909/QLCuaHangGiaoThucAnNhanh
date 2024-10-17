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

namespace GUI
{
    public partial class frmDonHang : Form
    {
        public Cluster cluster;
        public ISession session;
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
                loadDSDonHang();
                data_binding();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!");
            }

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
            var rs = session.Execute("SELECT madh, makh, ngaydat, tongtien, ptthanhtoan, trangthai FROM donhang");

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Đơn Hàng", typeof(string));
            dt.Columns.Add("Tên Khách Hàng", typeof(string));
            dt.Columns.Add("Ngày Đặt", typeof(DateTime));
            dt.Columns.Add("Tổng Tiền", typeof(string));
            dt.Columns.Add("PT Thanh Toán", typeof(string));
            dt.Columns.Add("Trạng Thái", typeof(string));

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

        private void btnThemDH_Click(object sender, EventArgs e)
        {
            txtMaDH.Clear();
            dtpNgayDat.Value = DateTime.Now;
            txtTongTien.Clear();
            txtPTTT.Clear();
            txtTrangThai.Clear();

            txtMaDH.Focus();

            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã Đơn Hàng!");
                txtMaDH.Focus();
            }

            if (dtpNgayDat.Value > DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn Ngày Đặt hợp lệ!");
                txtMaDH.Focus();
            }

            if (txtTongTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Tổng Tiền!");
                txtMaDH.Focus();
            }

            if (txtPTTT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập PT Thanh Toán!");
                txtMaDH.Focus();
            }

            if (txtTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Trạng Thái!");
                txtMaDH.Focus();
            }

            try
            {
                string query = "INSERT INTO donhang (makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai) VALUES (?, ?, ?, ?, ?, ?)";

                var preparedStatement = session.Prepare(query);

                string makh = cboKH.SelectedValue.ToString();
                string madh = txtMaDH.Text;
                double tongtien = double.Parse(txtTongTien.Text);
                DateTime ngaydat = dtpNgayDat.Value;
                string ptthanhtoan = txtPTTT.Text;
                string trangthai = txtTrangThai.Text;

                var boundStatement = preparedStatement.Bind(makh, madh, tongtien, ngaydat, ptthanhtoan, trangthai);

                session.Execute(boundStatement);

                MessageBox.Show("Thêm đơn hàng thành công!");
                loadDSDonHang();
            }
            catch
            {
                MessageBox.Show("Thêm đơn hàng thất bại!");
            }
        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xóa!");
                return;
            }

            try
            {
                string query = "DELETE FROM donhang WHERE madh = ? AND makh = ? AND tongtien = ?";

                var preparedStatement = session.Prepare(query);

                string madh = txtMaDH.Text;
                string makh = cboKH.SelectedValue.ToString();
                double tongtien = double.Parse(txtTongTien.Text);
                var boundStatement = preparedStatement.Bind(madh, makh, tongtien);

                session.Execute(boundStatement);

                MessageBox.Show("Xóa đơn hàng thành công!");
                loadDSDonHang();
            }
            catch
            {
                MessageBox.Show("Xóa đơn hàng thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDSDonHang();
        }
    }
}
