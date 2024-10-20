
namespace DTO
{
    public class MonAnDTO
    {
        public MonAnDTO() { }
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public string TenLoai {  get; set; }
        public double Gia { get; set; }
        public int SLDaDat { get; set; } = 0;
        public string? HinhAnhMonAn { get; set; }
    }
}
