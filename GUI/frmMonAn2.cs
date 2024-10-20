using Cassandra;
using DTO;
using System.Data;
using System.Windows.Forms;
namespace GUI
{
    public partial class frmMonAn2 : Form
    {
        private ISession session;
        private List<MonAnDTO> dsMonAn = new List<MonAnDTO>();
        public string maMonAn { get; set; }
        public frmMonAn2()
        {
            InitializeComponent();
            khoiTaoKetNoi();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmChiTietMonAn frm = new frmChiTietMonAn();
            frm.Show();
        }

        // Khởi tạo kết nối với Cassandra
        private void khoiTaoKetNoi()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("localhost")
                .Build();
            session = cluster.Connect("qlgiaotan");
        }

        // Lấy danh sách món ăn từ Cassandra
        private List<MonAnDTO> LayDanhSachMonAn()
        {
            List<MonAnDTO> monans = new List<MonAnDTO>();
            var result = session.Execute("SELECT mamonan, gia, sldadat, tenloai, tenmon FROM monan");
            
            foreach (var item in result)
            {
                monans.Add(new MonAnDTO
                {
                    MaMonAn = item.GetValue<string>("mamonan"),
                    Gia = item.GetValue<double>("gia"),
                    SLDaDat = item.GetValue<int>("sldadat"),
                    TenLoai = item.GetValue<string>("tenloai"),
                    TenMonAn = item.GetValue<string>("tenmon")
                });
            }
            return monans;
        }

        // Hiển thị dữ liệu trên DataGridView
        private void HienThiMonAn(List<MonAnDTO> dsMonAn)
        {
            if (dsMonAn.Count > 0)
            {
                dgvMonAn.DataSource = dsMonAn;
            }
        }
        private void frmMonAn2_Load(object sender, EventArgs e)
        {
            dsMonAn = LayDanhSachMonAn();
            // Đặt tên cho các cột
            dgvMonAn.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Tạo các cột thủ công và đặt tên hiển thị
            dgvMonAn.Columns.Clear();

            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaMonAn",
                HeaderText = "Mã Món Ăn",
                Name = "MaMonAn"
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenMonAn",
                HeaderText = "Tên Món Ăn",
                Name = "TenMonAn"
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Giá",
                Name = "Gia"
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SLDaDat",
                HeaderText = "Số Lượng Đã Đặt",
                Name = "SLDaDat"
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenLoai",
                HeaderText = "Loại Món Ăn",
                Name = "TenLoai"
            });
            HienThiMonAn(dsMonAn);
        }
        private void xoaMonAn(string maMonAn)
        {
            if (maMonAn != null)
            {
                session.Execute("DELETE FROM monan WHERE mamonan='" + maMonAn + "'");
                dsMonAn = LayDanhSachMonAn();
                HienThiMonAn(dsMonAn);
            }
        }
        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(tuKhoa))
            {

                var ketQua = dsMonAn.Where(monAn => monAn.TenMonAn.ToLower().Contains(tuKhoa)).ToList();
                HienThiMonAn(ketQua);
            }
            else
            {
                HienThiMonAn(dsMonAn);
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra hàng hợp lệ
            {
             maMonAn = dgvMonAn.Rows[e.RowIndex].Cells["MaMonAn"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có hàng nào được chọn
            if (dgvMonAn.SelectedRows.Count > 0)
            {
                // Lấy mã món ăn từ hàng đã chọn
                string maMonAn = dgvMonAn.SelectedRows[0].Cells["MaMonAn"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi hàm xóa món ăn
                    xoaMonAn(maMonAn);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmChiTietMonAn frmSua=new frmChiTietMonAn();
            frmSua.maMonAn = maMonAn;
            frmSua.Show();
        }
    }
}
