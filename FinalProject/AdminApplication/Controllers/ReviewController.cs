using AdminApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AdminApplication.Controllers
{
    public class ReviewController : Controller
    {
        public IReviewRepository _review;
        public ReviewController(IReviewRepository review)
        {
           _review = review;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
