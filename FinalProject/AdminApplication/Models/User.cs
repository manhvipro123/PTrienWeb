using System;
using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class User
    {
        public User()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
