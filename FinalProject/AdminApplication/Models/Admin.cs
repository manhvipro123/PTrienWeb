using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdminApplication.Models
{
    public partial class Admin
    {
        public int UserAd { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [MinLength(4,ErrorMessage ="Chiều dài mật khẩu < 4")]
        [MaxLength(15,ErrorMessage ="Chiều dài mật khẩu > 15")]
        public string? Password { get; set; }
       /* [Required(ErrorMessage = "Vui lòng điền tên tài khoản")]*/
        public string? Name { get; set; }
        [Required(ErrorMessage = "Vui lòng điền email")]
        [EmailAddress(ErrorMessage = "Email điền vào không hợp lệ!")]
        public string? Email { get; set; }
    }
}
