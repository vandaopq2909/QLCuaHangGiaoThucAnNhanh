using Cassandra;

namespace GUI
{
    public partial class frmChinh : Form
    {
        public string tenDangNhap { get; set; }
        public frmChinh()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


        }
        public void LoadNutChoNguoiDung()
        {
            if (tenDangNhap != null)
            {

                var cluster = Cluster.Builder().AddContactPoints("localhost").Build();
                var session = cluster.Connect("qlgiaotan");
                var statement = session.Prepare("select vaitro from nguoidung where tendangnhap = ?;");
                var result = session.Execute(statement.Bind(tenDangNhap));
                var row = result.FirstOrDefault();
                string tenVaiTro = string.Empty;
                if (row != null)
                {
                    tenVaiTro = row.GetValue<string>("vaitro");
                    lblTenDN.Text = tenDangNhap.ToString() + " " + "(" + tenVaiTro + ")";
                }
                //Kiểm tra có phải admin không
                if (tenVaiTro == "Admin")
                {
                    btnNhanVien.Visible = true;
                }

            }


        }
        public void AddControl(Form f)
        {
            panelCenter.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panelCenter.Controls.Add(f);
            f.Show();
        }
        private void frmChinh_Load(object sender, EventArgs e)
        {
            LoadNutChoNguoiDung();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            AddControl(new frmMonAn());
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            AddControl(new frmMonAn2());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            AddControl(new frmDonHang());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            AddControl(new frmNhanVien());
        }

        private void frmChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            AddControl(new frmKhuyenMai());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            AddControl(new frmKhachHang());
        }
    }
}
