using Cassandra;
using DTO;

namespace GUI
{
    public partial class frmMonAn : Form
    {
        private ISession session;
        public frmMonAn()
        {
            InitializeComponent();
        
        }

        private void guna2TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2TextBox1.Text = string.Empty;
        }
        private void khoiTaoKetNoi()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("localhost")
                .Build();
            session = cluster.Connect("qlgiaotan");
        }
        private List<MonAnDTO> LayDanhSachMonAn()
        {
            List<MonAnDTO> dsMonAn = new List<MonAnDTO>();
            var rows = session.Execute("SELECT mamonan, tenmon, gia, hinhanh FROM monan;");

            foreach (var row in rows)
            {
                MonAnDTO monAn = new MonAnDTO
                {
                    MaMonAn = row.GetValue<string>("mamonan"),
                    TenMonAn = row.GetValue<string>("tenmon"),
                    Gia = row.GetValue<Double>("gia"),
                    HinhAnhMonAn = row.GetValue<string>("hinhanh")
                };

                dsMonAn.Add(monAn);
            }
            return dsMonAn;
        }


        private void HienThiMonAn()
        {
            // Xóa các control cũ nếu có
            panelMonAn.Controls.Clear();


            // Khởi tạo một danh sách các món ăn (đây là dữ liệu giả lập, bạn có thể thay thế bằng dữ liệu thực tế)
            List<MonAnDTO> dsMonAn = LayDanhSachMonAn();  // Giả định hàm này trả về danh sách món ăn

            // Duyệt qua từng món ăn và hiển thị
            foreach (var monAn in dsMonAn)
            {
                // Tạo mới một đối tượng ucMonAn
                ucMonAn uc = new ucMonAn();

                // Gán giá trị cho các thuộc tính
                uc.maMonAn = monAn.MaMonAn;
                uc.tenMonAn = monAn.TenMonAn;
                if (!string.IsNullOrEmpty(monAn.HinhAnhMonAn))
                {
                    uc.hinhAnh = Image.FromFile(monAn.HinhAnhMonAn);
                }
                else
                {
                    uc.hinhAnh = Image.FromFile("C:\\Users\\HUNG\\source\\repos\\QLGiaoTAN_Cassandra\\GUI\\Resources\\dish.png");
                }
                uc.gia = monAn.Gia;


                // Thêm ucMonAn vào panel
                panelMonAn.Controls.Add(uc);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmChiTietMonAn frm = new frmChiTietMonAn();
            frm.Show();
        }

        private void frmMonAn_Load(object sender, EventArgs e)
        {
            khoiTaoKetNoi();
            HienThiMonAn();

        }
    }
}
