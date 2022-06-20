using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminApplication.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaDm { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string? TenDm { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
