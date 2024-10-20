namespace DTO
{
    public class NguoiDungDTO
    {
        public NguoiDungDTO(string tenDangNhap, string matKhau)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }

        public string tenDangNhap { get; set; }
        public string matKhau {  get; set; }
    }
}
