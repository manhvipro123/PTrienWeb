using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Repository;
using CustomerApplication.Models;
namespace CustomerApplication.Controllers
{
    public class StoreCustomerController : Controller
    {
        IDanhGiaRepository _rep;
        public StoreCustomerController(IDanhGiaRepository rep)
        {
            _rep = rep;
        }
        public IActionResult Index()
        {
            List<DanhGia> danhgias = _rep.getAllDanhGias();
            ViewBag.danhgias = danhgias;
            return View();
        }
    }
}
