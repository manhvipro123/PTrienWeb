using System;
using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaDm { get; set; }
        public string? TenDm { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
