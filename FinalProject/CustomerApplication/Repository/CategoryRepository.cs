using CustomerApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CustomerApplication.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        StoreContext ctx = new StoreContext();
        public List<SanPham> getAllSanPhams()
        {
            return ctx.SanPhams.Include(x => x.ChiTietDonHangs).ToList();
        }
    }
}
