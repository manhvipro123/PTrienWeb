using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class DanhGia
    {
        public int MaDg { get; set; }
        public int? MaKh { get; set; }
        public int? MucDg { get; set; }
        public int? MaSp { get; set; }
        public string? NhanXet { get; set; }

        public virtual KhachHang? MaKhNavigation { get; set; }
        public virtual SanPham? MaSpNavigation { get; set; }
    }
}
