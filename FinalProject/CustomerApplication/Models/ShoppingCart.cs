namespace CustomerApplication.Models
{
    public partial class ShoppingCart
    {
        public string CartId { get; set; }
        public int MaSp { get; set; }
        public int? Sl { get; set; }
        public SanPham MaSpNavigation { get; set; }
    }
}
