namespace DTO
{
    public class NguoiDungDTO
    {
        public NguoiDungDTO(string tenDangNhap, string matKhau)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }
        public NguoiDungDTO() { }
        public string tenDangNhap { get; set; }
        public string matKhau {  get; set; }
        public string vaiTro {  get; set; }
    }
}
