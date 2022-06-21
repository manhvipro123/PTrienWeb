using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Repository;
namespace CustomerApplication.Controllers
{
    public class ReviewController : Controller
    {
        private IDanhGiaRepository _danhgia;
        public ReviewController(IDanhGiaRepository danhgia)
        {
            _danhgia = danhgia;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
