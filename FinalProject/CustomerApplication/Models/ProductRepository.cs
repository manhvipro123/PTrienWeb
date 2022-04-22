namespace CustomerApplication.Models
{
    public class ProductRepository
    {
        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Image = "kiwi.jpg", Name = "kiwi" },
                new Product() { Image = "mango.jpg", Name = "kiwi" },
                new Product() { Image = "grapes.jpg", Name = "kiwi" },
            };
            return products;
        }
    }
}
