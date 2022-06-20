using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace AdminApplication.Models

{
    public class SanPhamModel : SanPham
    {
        public IFormFile FormFile { get; set; }
    }
}
