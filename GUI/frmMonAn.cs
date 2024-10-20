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
            txtTimKiem.Text = string.Empty;
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
                    uc.hinhAnh = Image.FromFile("C:\\Users\\VANDAO\\Desktop\\data_cassandra\\App\\DuPhong\\QLCuaHangGiaoThucAnNhanh\\GUI\\Resources\\dish.png");
                }
                uc.gia = monAn.Gia;


                // Thêm ucMonAn vào panel
                panelMonAn.Controls.Add(uc);
            }
        }
        private List<MonAnDTO> timKiemMonAn(string tuKhoa)
        {
            List<MonAnDTO> dsMonAn = LayDanhSachMonAn();

            // Lọc danh sách món ăn dựa trên từ khóa
            var ketQua = dsMonAn
                .Where(monAn => monAn.TenMonAn.ToLower().Contains(tuKhoa.ToLower()))
                .ToList();

            return ketQua;
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
        private void HienThiMonAn(List<MonAnDTO> dsMonAn)
        {
            // Xóa các control cũ nếu có
            panelMonAn.Controls.Clear();

            // Duyệt qua từng món ăn và hiển thị
            foreach (var monAn in dsMonAn)
            {
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
                    uc.hinhAnh = Image.FromFile("C:\\Users\\VANDAO\\Desktop\\data_cassandra\\App\\DuPhong\\QLCuaHangGiaoThucAnNhanh\\GUI\\Resources\\dish.png");
                }
                uc.gia = monAn.Gia;

                // Thêm ucMonAn vào panel
                panelMonAn.Controls.Add(uc);
            }
        }
        private List<MonAnDTO> timKiemMonAnTheoLoai(string tenLoai)
        {
            List<MonAnDTO> dsMonAnTheoLoai = new List<MonAnDTO>();
            // Lọc danh sách món ăn dựa trên loại món ăn
            var rows = session.Execute("SELECT mamonan, tenmon, gia, hinhanh FROM monan where tenloai='" + tenLoai + "' allow filtering;");

            foreach (var row in rows)
            {
                MonAnDTO monAn = new MonAnDTO
                {
                    MaMonAn = row.GetValue<string>("mamonan"),
                    TenMonAn = row.GetValue<string>("tenmon"),
                    Gia = row.GetValue<Double>("gia"),
                    HinhAnhMonAn = row.GetValue<string>("hinhanh")
                };

                dsMonAnTheoLoai.Add(monAn);
            }
            return dsMonAnTheoLoai;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            // Kiểm tra nếu từ khóa không rỗng, thực hiện tìm kiếm
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                var dsKetQua = timKiemMonAn(tuKhoa);
                HienThiMonAn(dsKetQua);
            }
            else
            {
                // Nếu không có từ khóa, hiển thị tất cả món ăn
                var dsMonAn = LayDanhSachMonAn();
                HienThiMonAn(dsMonAn);
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Mì");
            HienThiMonAn(dsKetQua);
        }

        private void btnBanhMi_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Bánh mì");
            HienThiMonAn(dsKetQua);
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Pizza");
            HienThiMonAn(dsKetQua);
        }

        private void btnBurger_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Burger");
            HienThiMonAn(dsKetQua);
        }

        private void btnNuocUong_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Nước uống");
            HienThiMonAn(dsKetQua);
        }

        private void btnKem_Click(object sender, EventArgs e)
        {
            var dsKetQua = timKiemMonAnTheoLoai("Kem");
            HienThiMonAn(dsKetQua);
        }
    }
}
