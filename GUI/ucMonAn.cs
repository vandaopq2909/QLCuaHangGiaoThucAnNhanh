
namespace GUI
{
    public partial class ucMonAn : UserControl
    {
        public EventHandler onSelect = null;
        public ucMonAn()
        {
            InitializeComponent();
        }
        public string maMonAn { get; set; }
        public string tenMonAn
        {
            get { return lblTenMon.Text; }
            set { lblTenMon.Text = value; }
        }
        public Image hinhAnh
        {
            get { return hinh_MonAn.Image; }
            set { hinh_MonAn.Image = value; }
        }
        public double gia
        {
            get { return Double.Parse(lblGia.Text); }
            set { lblGia.Text = value.ToString()+" vnđ"; }
        }
        private void hinh_MonAn_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void ucMonAn_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
        }
    }
}
