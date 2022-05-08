using System;
using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class Admin
    {
        public int UserAd { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
