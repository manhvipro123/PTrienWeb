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

        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        public string? TenSp { get; set; }
       
        public int? MaDm { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập giá")]
        public decimal? Gia { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập số lượng")]
        public int? SoLuong { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày nhập")]
        public DateTime? NgayNhap { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập mô tả")]
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh")]
        public string? HinhAnh { get; set; }
  /*      [Required(ErrorMessage = "Vui lòng nhập gói sản phẩm")]*/
        public int? Goi { get; set; }
  /*      [Required(ErrorMessage = "Vui lòng nhập trạng đặc điểm")]*/
        public string? DacDiem { get; set; }

        public virtual DanhMuc? MaDmNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<DanhGia> DanhGias { get; set; }
    }
}
