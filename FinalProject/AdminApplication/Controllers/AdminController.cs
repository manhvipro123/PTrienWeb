using Microsoft.AspNetCore.Mvc;

namespace AdminApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
