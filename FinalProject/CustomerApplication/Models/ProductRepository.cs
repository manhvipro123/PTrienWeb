using Microsoft.AspNetCore.Mvc;

namespace CustomerApplication.Models
{
    public class ProductRepository
    {
        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { TenSp1 = "Bao Cao Su Durex Invisible Extra Thin, Extra Lubricated Hộp 10 Cái", HinhAnh1 = "hinh1.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Invisible Extra Thin Extra Sensitive Hộp 10 Cái", HinhAnh1 = "hinh2.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Invisible Extra Thin Extra Sensitive Hộp 3 Cái", HinhAnh1 = "hinh3.png"  },
                new Product() { TenSp1 = "Bao cao su Durex Fether Ultima hộp 12 Cái", HinhAnh1 = "hinh4.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Fether Ultima Hộp 3 Cái", HinhAnh1 = "hinh5.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Fetherlite Hộp 12 Cái", HinhAnh1 = "hinh6.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Fetherlite Hộp 3 Cái", HinhAnh1 = "hinh7.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Performa Hộp 12 Cái", HinhAnh1 = "hinh8.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Performa Hộp 3 Cái", HinhAnh1 = "hinh9.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Pleasuremax Hộp 12 Cái", HinhAnh1 = "hinh10.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Pleasuremax Hộp 3 Cái", HinhAnh1 = "hinh11.png"  },
                new Product() { TenSp1 = "Bao Cao Su Durex Kingtex Hộp 12 Cái", HinhAnh1 = "hinh12.png"  },

                /*new SanPham() { Image = "mango.jpg", Name = "kiwi" },
                new SanPham() { Image = "grapes.jpg", Name = "kiwi" },*/
            };
            return products;
        }
    }
}




