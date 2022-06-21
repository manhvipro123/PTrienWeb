using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class ChiTietDonHang
    {
        public int MaCtdh { get; set; }
        public string MaDh { get; set; } = null!;
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual DonHang MaDhNavigation { get; set; } = null!;
        public virtual SanPham? MaSpNavigation { get; set; }
    }
}
