using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Controllers;
using CustomerApplication.Repository;
using CustomerApplication.Models;
namespace CustomerApplication.Controllers
{
    public class ProductController : Controller
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            List<SanPham> lst = categoryRepository.getAllSanPhams();
            return View(lst);
        }
    }
}
