using System;
using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class DanhGia
    {
        public int MaDg { get; set; }
        public string MaKh { get; set; } = null!;
        public int? MucDg { get; set; }
        public int? MaSp { get; set; }
        public string? NhanXet { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; } = null!;
        public virtual SanPham? MaSpNavigation { get; set; }
    }
}
