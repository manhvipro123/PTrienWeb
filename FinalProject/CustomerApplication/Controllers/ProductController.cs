using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Controllers;
using CustomerApplication.Repository;
using CustomerApplication.Models;
namespace CustomerApplication.Controllers
{
    public class ProductController : Controller
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        StoreContext ctx = new StoreContext();
        public IActionResult Index()
        {
            List<SanPham> lst = categoryRepository.getAllSanPhams();
            return View(lst);
        }

        public IActionResult Details (int masp)
        {
            SanPham sanpham = ctx.SanPhams.Where(x => x.MaSp == masp).SingleOrDefault();

            return View(sanpham);
        }

    }
}
