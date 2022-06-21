using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AdminApplication.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhGias = new HashSet<DanhGia>();
        }

        public int MaSp { get; set; }
        [Required(ErrorMessage = "Vui lòng điền tên sản phẩm")]
        public string? TenSp { get; set; }
        
        public int? MaDm { get; set; }
        [Required(ErrorMessage = "Vui lòng điền giá")]
        public decimal? Gia { get; set; }
        [Required(ErrorMessage = "Vui lòng điền số lượng sản phẩm")]
        public int? SoLuong { get; set; }
        [Required(ErrorMessage = "Vui lòng điền ngày nhập sản phẩm")]
        public DateTime? NgayNhap { get; set; }
        public string? DacDiem { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mô tả sản phẩm")]
        public string? MoTa { get; set; }
        public int? Goi { get; set; }
        public string? TrangThai { get; set; }
        public string? HinhAnh { get; set; }

        public virtual DanhMuc? MaDmNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<DanhGia> DanhGias { get; set; }
    }
}
