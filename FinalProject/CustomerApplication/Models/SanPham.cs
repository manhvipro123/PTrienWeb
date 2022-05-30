using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhGias = new HashSet<DanhGia>();
        }

        public int MaSp { get; set; }
        public string? TenSp { get; set; }
        public int? MaDm { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }
        public string? HinhAnh { get; set; }

        public virtual DanhMuc? MaDmNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<DanhGia> DanhGias { get; set; }
    }
}
