using Cassandra;
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
    public partial class frmDangKi : Form
    {
        private ISession session;
        public frmDangKi()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }
        private void khoiTaoKetNoi()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("localhost")
                .Build();
            session = cluster.Connect("qlgiaotan");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNhapLai.Text))
            {
                MessageBox.Show("Vui nhập mật khẩu nhập lại");
                return;
            }
            if (txtMatKhau.ToString() != txtNhapLai.ToString())
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                return;
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);

            var cql = session.Prepare("INSERT INTO nguoidung (tendangnhap, matkhau, vaitro) VALUES (?, ?, ?);");
            var bindvalue = cql.Bind(txtTenDangNhap.Text, hashedPassword, "Admin");
            session.Execute(bindvalue);
            MessageBox.Show("Tạo tài khoản thành công");
            frmDangNhap frmDN=new frmDangNhap();
            frmDN.Show();
            this.Hide();
        }

        private void frmDangKi_Load(object sender, EventArgs e)
        {
            khoiTaoKetNoi();
        }
    }
}
