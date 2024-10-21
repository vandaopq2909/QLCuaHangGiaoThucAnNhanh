using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Class
{
    internal class KhuyenMai
    {
        public required string MaMonAn { get; set; }
        public string? TenKM { get; set; }
        public string? TenMonAn { get; set; }
        public double TiLe { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public string? MoTa { get; set; }
    }
}
