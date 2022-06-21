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
        public string Id { get; set; } = null!;
        public string? TenKh { get; set; }
        public string UserId { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? DiaChiKh { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
