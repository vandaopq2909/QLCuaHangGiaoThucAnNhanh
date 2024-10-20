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
    public partial class frmChiTietMonAn : Form
    {
        private ISession session;
        public frmChiTietMonAn()
        {
            InitializeComponent();
            khoiTaoKetNoi();
        }
        string filePath;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtHinhAnh.Image = new Bitmap(filePath);
            }
        }
        private void LoadLoaiMonAn()
        {
            // Danh sách các loại món ăn
            List<string> loaiMonAn = new List<string>
            {
                "Bánh mì",
                "Pizza",
                "Burger",
                "Kem",
                "Nước uống",
                "Mì"
            };
            // Thêm từng loại vào ComboBox
            cboLoaiMon.Items.AddRange(loaiMonAn.ToArray());
            cboLoaiMon.SelectedIndex = 0;
        }

        private void frmChiTietMonAn_Load(object sender, EventArgs e)
        {
            LoadLoaiMonAn();
        }
        private void khoiTaoKetNoi()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("localhost")
                .Build();
            session = cluster.Connect("qlgiaotan");
        }
        private void themMonAn(MonAnDTO monAn)
        {

            var query = "INSERT INTO monan (mamonan, gia, hinhanh, sldadat, tenloai, tenmon) VALUES (?, ?, ?, ?, ?, ?)";
            var preparedStatement = session.Prepare(query);
            var statement = preparedStatement.Bind(monAn.MaMonAn, monAn.Gia, monAn.HinhAnhMonAn,monAn.SLDaDat ,monAn.TenLoai ,monAn.TenMonAn);
            session.Execute(statement);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMonAn.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.");
                return;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập giá.");
                return;
            }
            MonAnDTO monAn = new MonAnDTO
            {
                MaMonAn = "MaMon" + Guid.NewGuid().ToString().Substring(0, 6),
                TenMonAn = txtTenMonAn.Text,
                TenLoai = cboLoaiMon.SelectedItem.ToString(),
                HinhAnhMonAn = filePath, // Đường dẫn hình ảnh
                Gia = Double.Parse(txtGia.Text),
            };

            if (monAn.Gia <= 0)
            {
                MessageBox.Show("Giá phải lớn hơn 0.");
                return;
            }
            themMonAn(monAn);

            // Hiển thị thông báo thành công
            MessageBox.Show("Đã thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa các trường nhập để thêm món ăn mới
            txtTenMonAn.Clear();
            txtGia.Clear();
            txtHinhAnh.Image = null;
        }
    }
}
