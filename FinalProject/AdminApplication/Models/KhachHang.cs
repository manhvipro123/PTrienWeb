using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminApplication.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DanhGias = new HashSet<DanhGia>();
            DonHangs = new HashSet<DonHang>();
        }

        public int MaKh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string? TenKh { get; set; }
     
        public int? UserId { get; set; }
        [StringLength(10)]
        [MinLength(9,ErrorMessage ="Số điện thoại ít hơn 9 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại nhập vào không hợp lệ")]
        public string? Sdt { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string? DiaChiKh { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
