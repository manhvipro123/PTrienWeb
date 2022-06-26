using CustomerApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CustomerApplication.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        StoreContext ctx = new StoreContext();

        /*public void createItem(SanPham sp)
        {
            ctx.SanPhams.Add(sp);
            ctx.SaveChanges();
        }*/

        public List<SanPham> getAllSanPhams()
        {
            return ctx.SanPhams.Include(x => x.ChiTietDonHangs).ToList();
        }

        /*public List<SanPham> getGoi3()
        {
            return ctx.SanPhams.OrderBy(x => x.Goi).Take(3).ToList();

        }*/
    }
}
