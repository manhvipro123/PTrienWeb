using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int MaDh { get; set; }
        public int? MaKh { get; set; }
        public string? DiaChiGiao { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string? TrangThaiDh { get; set; }
        public string? PhuongThucTt { get; set; }
        public string? Cod { get; set; }
        public string? TheTinDung { get; set; }
        public string? NganHangNhan { get; set; }
        public int? SoThe { get; set; }
        public decimal? TongTien { get; set; }

        public virtual KhachHang? MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
