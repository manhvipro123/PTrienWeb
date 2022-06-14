using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AdminApplication.Models
{
    public partial class Admin
    {
        public int UserAd { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
      /*  [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]*/
        public string? Password { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập vào email")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ")]
        public string? Email { get; set; }
    }
}
