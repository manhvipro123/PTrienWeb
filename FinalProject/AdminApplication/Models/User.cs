using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AdminApplication.Models
{
    public partial class User
    {
        public User()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        public string? Email { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
