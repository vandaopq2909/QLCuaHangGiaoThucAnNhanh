using Cassandra;
using GUI.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        private ISession session;
        public frmKhachHang()
        {
            InitializeComponent();
            InitializeCassandra();
            LoadData();
        }
        private void InitializeCassandra()
        {
            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            session = cluster.Connect("qlgiaotan");
        }
        public bool IsTextEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            return phoneNumber.Length == 10 && Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
        //protected override void OnFormClosed(FormClosedEventArgs e)
        //{
        //    session.Dispose();
        //    base.OnFormClosed(e);
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            List<Khachhang> khs = new List<Khachhang>();
            var result = session.Execute("select * from khachhang");

            foreach (var item in result)
            {
                khs.Add(new Khachhang
                {
                    MaKH = item.GetValue<string>("makh"),
                    Email = item.GetValue<string>("email"),
                    SDT = item.GetValue<string>("sdt"),
                    TenKH = item.GetValue<string>("tenkh"),
                });
            }

            if (khs.Count > 0)
            {
                GV_KH.Rows.Clear();
                foreach (var kh in khs)
                {
                    GV_KH.Rows.Add(kh.MaKH, kh.TenKH, kh.SDT, kh.Email);
                }
            }
        }

        private void GV_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GV_KH.Rows[e.RowIndex];

                string maKH = row.Cells["cMaKH"].Value?.ToString() ?? string.Empty;
                string email = row.Cells["cEmail"].Value?.ToString() ?? string.Empty;
                string sdt = row.Cells["cSDT"].Value?.ToString() ?? string.Empty;
                string tenKH = row.Cells["cTenKH"].Value?.ToString() ?? string.Empty;

                txt_MaKH.ReadOnly = true;
                txt_MaKH.Text = maKH;
                txt_email.Text = email;
                txt_sdt.Text = sdt;
                txt_TenKH.Text = tenKH;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_MaKH.ReadOnly = false;
            txt_MaKH.Clear();
            txt_email.Clear();
            txt_sdt.Clear();
            txt_TenKH.Clear();
            LoadData();

        }

        private void btn_save_KH_Click(object sender, EventArgs e)
        {
            if (IsTextEmpty(txt_MaKH.Text) || IsTextEmpty(txt_email.Text) || IsTextEmpty(txt_sdt.Text) || IsTextEmpty(txt_TenKH.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm.", "Thông báo");
                return;
            }
            try
            {
                string maKH = txt_MaKH.Text;
                string email = txt_email.Text;
                string sdt = txt_sdt.Text;
                string tenKH = txt_TenKH.Text;

                //Check
                string checkQuery = "SELECT COUNT(*) FROM khachhang WHERE makh = ?";
                var checkStatement = session.Prepare(checkQuery);
                var checkBoundStatement = checkStatement.Bind(maKH);
                var result = session.Execute(checkBoundStatement);

                var count = result.First().GetValue<long>("count");

                if (count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.", "Thông báo");
                    return;
                }

                if (IsValidName(tenKH) == false)
                {
                    MessageBox.Show("Tên khách hàng không hợp lệ!", "Thông báo");
                    return;
                }

                if (IsValidEmail(email) == false)
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo");
                    return;
                }

                if (IsValidPhoneNumber(sdt) == false)
                {
                    MessageBox.Show("Số điện thoại là số và 10 chữ số!", "Thông báo");
                    return;
                }

                string insertQuery = "INSERT INTO khachhang (makh, email, sdt, tenkh) VALUES (?, ?, ?, ?)";
                var insertStatement = session.Prepare(insertQuery);
                var insertBoundStatement = insertStatement.Bind(maKH, email, sdt, tenKH);

                session.Execute(insertBoundStatement);

                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void btn_update_KH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này không?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maKH = txt_MaKH.Text;
                    string email = txt_email.Text;
                    string sdt = txt_sdt.Text;
                    string tenKH = txt_TenKH.Text;

                    if (IsValidName(tenKH) == false)
                    {
                        MessageBox.Show("Tên khách hàng không hợp lệ!", "Thông báo");
                        return;
                    }

                    if (IsValidEmail(email) == false)
                    {
                        MessageBox.Show("Email không hợp lệ!", "Thông báo");
                        return;
                    }

                    if (IsValidPhoneNumber(sdt) == false)
                    {
                        MessageBox.Show("Số điện thoại là số và 10 chữ số!", "Thông báo");
                        return;
                    }

                    string query = "UPDATE khachhang SET email = ?, sdt = ?, tenkh = ? WHERE makh = ?";
                    var preparedStatement = session.Prepare(query);
                    var boundStatement = preparedStatement.Bind(email, sdt, tenKH, maKH);

                    session.Execute(boundStatement);

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maKH = txt_MaKH.Text;

                    if (IsTextEmpty(maKH))
                    {
                        MessageBox.Show("Chọn khách hàng cần xóa!", "Thông báo");
                        return;
                    }

                    string query = "DELETE FROM khachhang WHERE makh = ?";
                    var preparedStatement = session.Prepare(query);
                    var boundStatement = preparedStatement.Bind(maKH);

                    session.Execute(boundStatement);

                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
        }

        private void text_search_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                UpdateCustomerData(text_search_KH.Text.Trim());
            }
        }
        private void SearchCustomer(string keyword)
        {
            try
            {
                List<Khachhang> khs = new List<Khachhang>();

                string query = "SELECT * FROM khachhang ALLOW FILTERING";
                var result = session.Execute(query);

                foreach (var item in result)
                {
                    var kh = new Khachhang
                    {
                        MaKH = item.GetValue<string>("makh"),
                        Email = item.GetValue<string>("email"),
                        SDT = item.GetValue<string>("sdt"),
                        TenKH = item.GetValue<string>("tenkh"),
                    };

                    if (kh.TenKH.Contains(keyword, StringComparison.OrdinalIgnoreCase) || kh.SDT.Contains(keyword) || kh.Email.Contains(keyword) || kh.MaKH.Contains(keyword))
                    {
                        khs.Add(kh);
                    }
                }

                if (khs.Count > 0)
                {
                    GV_KH.Rows.Clear();
                    foreach (var kh in khs)
                    {
                        GV_KH.Rows.Add(kh.MaKH, kh.TenKH, kh.SDT, kh.Email);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào.", "Kết quả tìm kiếm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCustomerData(text_search_KH.Text.Trim());
        }
        private void UpdateCustomerData(string keyword)
        {
            List<Khachhang> khachhangs = new List<Khachhang>();

            try
            {
                List<string> paymentMethods = new List<string>();
                if (cb_tien.Checked)
                {
                    paymentMethods.Add("Tiền mặt");
                }
                if (cb_chuyenkhoan.Checked)
                {
                    paymentMethods.Add("Chuyển khoản");
                }

                if (paymentMethods.Count == 0)
                {
                    GV_KH.Rows.Clear();
                    SearchCustomer(text_search_KH.Text.Trim());
                    return;
                }

                foreach (var method in paymentMethods)
                {
                    // Tìm kiếm khách hàng dựa trên từ khóa và phương thức thanh toán
                    string query = "SELECT makh, madh, ptthanhtoan, sdt, tenkh FROM qlgiaotan.ttkhtheopttt WHERE ptthanhtoan = ? ALLOW FILTERING";
                    var statement = session.Prepare(query);
                    var boundStatement = statement.Bind(method);
                    var result = session.Execute(boundStatement);

                    foreach (var item in result)
                    {
                        string makh = item.GetValue<string>("makh");
                        string tenkh = item.GetValue<string>("tenkh");
                        string sdt = item.GetValue<string>("sdt");

                        if (string.IsNullOrWhiteSpace(keyword) || tenkh.Contains(keyword, StringComparison.OrdinalIgnoreCase) || sdt.Contains(keyword))
                        {
                            // Query customer emails from customer table
                            string customerQuery = "SELECT email FROM qlgiaotan.khachhang WHERE makh = ?";
                            var customerStatement = session.Prepare(customerQuery);
                            var customerBoundStatement = customerStatement.Bind(makh);
                            var customerResult = session.Execute(customerBoundStatement);

                            string email = customerResult.FirstOrDefault()?.GetValue<string>("email");

                            khachhangs.Add(new Khachhang
                            {
                                MaKH = item.GetValue<string>("makh"),
                                Email = email,
                                SDT = sdt,
                                TenKH = tenkh
                            });
                        }
                    }
                }

                // Show Customer
                GV_KH.Rows.Clear();
                if (khachhangs.Count > 0)
                {
                    foreach (var kh in khachhangs)
                    {
                        GV_KH.Rows.Add(kh.MaKH, kh.TenKH, kh.SDT, kh.Email);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào với các tiêu chí đã chọn.", "Kết quả tìm kiếm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }     
        private void UpdateCustomerData2()
        {
            List<Khachhang> khachhangs = new List<Khachhang>();

            try
            {
                List<string> paymentMethods = new List<string>();
                if (cb_tien.Checked)
                {
                    paymentMethods.Add("Tiền mặt");
                }
                if (cb_chuyenkhoan.Checked)
                {
                    paymentMethods.Add("Chuyển khoản");
                }

                if (paymentMethods.Count == 0)
                {
                    GV_KH.Rows.Clear();
                    LoadData();
                    return;
                }

                foreach (var method in paymentMethods)
                {
                    string query = "SELECT makh, madh, ptthanhtoan, sdt, tenkh FROM qlgiaotan.ttkhtheopttt WHERE ptthanhtoan = ? ALLOW FILTERING";
                    var statement = session.Prepare(query);
                    var boundStatement = statement.Bind(method);
                    var result = session.Execute(boundStatement);

                    foreach (var item in result)
                    {
                        string makh = item.GetValue<string>("makh");

                        // Truy vấn email khách hàng từ bảng khachhang
                        string customerQuery = "SELECT email FROM qlgiaotan.khachhang WHERE makh = ?";
                        var customerStatement = session.Prepare(customerQuery);
                        var customerBoundStatement = customerStatement.Bind(makh);
                        var customerResult = session.Execute(customerBoundStatement);

                        string email = customerResult.FirstOrDefault()?.GetValue<string>("email");

                        khachhangs.Add(new Khachhang
                        {
                            MaKH = item.GetValue<string>("makh"),
                            Email = email,
                            SDT = item.GetValue<string>("sdt"),
                            TenKH = item.GetValue<string>("tenkh")
                        });
                    }
                }

                // Hiển thị kết quả trong DataGridView
                GV_KH.Rows.Clear();
                if (khachhangs.Count > 0)
                {
                    foreach (var kh in khachhangs)
                    {
                        GV_KH.Rows.Add(kh.MaKH, kh.TenKH, kh.SDT, kh.Email);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào với phương thức thanh toán đã chọn.", "Kết quả tìm kiếm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }
    }
}