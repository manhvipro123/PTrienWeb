using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DanhGias = new HashSet<DanhGia>();
            DonHangs = new HashSet<DonHang>();
        }

        public int MaKh { get; set; }
        public string? TenKh { get; set; }
        public int? UserId { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChiKh { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
