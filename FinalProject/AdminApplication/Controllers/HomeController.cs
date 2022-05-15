using AdminApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace AdminApplication.Controllers
{
    public class HomeController : Controller
    {
        StoreContext ctx = new StoreContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login(Boolean id)
        {
            if(id == true)
            {
                ViewBag.Message = string.Format("Sign up Successfull!!!");
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAdmin(Admin ad, string rp_pass)
        {
            foreach (Admin adm in ctx.Admins)
            {
                if (adm.Email == ad.Email)
                {
                    ViewBag.Message = string.Format("Error.\\nYour email is existed !!!\\nPlease enter again ^^");
                    return View("Register");
                }
            }
            if (ad.Password == rp_pass)
            {
                ctx.Admins.Add(ad);
                ctx.SaveChanges();
                return RedirectToAction("Login", new { id = true });
            }
            else
            {
                ViewBag.Message = string.Format("Error.\\nYour password and repeat password is not correct!!!\\nPlease regist again ^^");
                return View("Register");
            }
        }

        [HttpPost]
        public IActionResult CheckAccount(string account, string pass)
        {
            var temp = false;
            foreach (Admin adm in ctx.Admins)
            {
                if(adm.Email == account && adm.Password == pass)
                {
                    temp = true;
                    return RedirectToAction("Index", "Admin", new {id = adm.UserAd});
                }
            }
            if(temp == false)
            {
                ViewBag.Message = string.Format("Your password or your email account is not correct" +
                    "\\n Please enter again!!!");
                return View("Login");
            }
            else
            {
                return View("Login");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}