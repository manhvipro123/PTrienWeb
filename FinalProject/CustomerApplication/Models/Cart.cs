namespace CustomerApplication.Models
{
    public class Cart
    {
        private List<ItemCart> carts = new List<ItemCart>();

        public void addItem(ItemCart item)
        {
            carts.Add(item);
        }

        public List<ItemCart> getAllSanPhams()
        {
            return carts;
        }

        public decimal getTongTien()
        {
            decimal tongTien = 0;
            foreach (ItemCart item in carts)
            {
                tongTien += item.Gia * item.SoLuong;
            }
            return tongTien;
        }
    }
}
