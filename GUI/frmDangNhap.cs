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
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        List<NguoiDungDTO> lsNguoiDung = new List<NguoiDungDTO>();
        Form frmChinh;
        public string tenDangNhap { get; set; }
        string tenVaiTro { get; set; } = string.Empty;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập " + lblTenDN.Text);
                txtTenDN.Focus();
                return;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập " + lblMatKhau.Text);
                txtMatKhau.Focus();
                return;
            }

            tenDangNhap = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string tenVaiTro = string.Empty;

            NguoiDungDTO nguoiDungDTO = new NguoiDungDTO(tenDangNhap, matKhau);
            var cluster = Cluster.Builder().AddContactPoints("localhost").Build();
            var session = cluster.Connect("qlgiaotan");

            //Dùng để lấy mk băm
            var statement1 = session.Prepare("SELECT * FROM nguoidung WHERE tendangnhap = ?;");
            var result1 = session.Execute(statement1.Bind(tenDangNhap));
            var row1 = result1.FirstOrDefault();

            var statement = session.Prepare("SELECT COUNT(*) FROM nguoidung WHERE tendangnhap = ? AND matkhau = ? allow filtering ;");
            var result = session.Execute(statement.Bind(tenDangNhap, matKhau));
            var row = result.FirstOrDefault();
            if (row != null && row1 != null)
            {
                string hashedPassword = row1.GetValue<string>("matkhau");

                if (BCrypt.Net.BCrypt.Verify(matKhau, hashedPassword))
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmChinh frmChinh = new frmChinh();
                    frmChinh.tenDangNhap = tenDangNhap;
                    frmChinh.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }

        }

        private void ckbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThiMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi frmDK = new frmDangKi();
            frmDK.Show();
            this.Hide();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
