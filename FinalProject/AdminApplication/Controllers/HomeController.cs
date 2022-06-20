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
            if (id == true)
            {
                ViewBag.Message = string.Format("Sign up Successfull!!!");
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(Admin ad)
        {
          
            if (ModelState.IsValid)
            {
                Admin adm = ctx.Admins.Where(x => x.Email == ad.Email).Where(y => y.Password == ad.Password).SingleOrDefault();
                if (adm != null)
                {
                    return RedirectToAction("Index", "Admin", new { id = adm.UserAd });
                }
                else
                {
                    /* ViewBag.Message = string.Format("Your password or your email account is not correct" +
                         "\\n Please enter again!!!");*/
                    ModelState.AddModelError(string.Empty, "Email or password is not correct!!!");
                    return View(ad);
                }
            }
            else 
            {
                return View(ad);
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
        public IActionResult Register(Admin ad, string rp_pass)
        {
            if (ModelState.IsValid)
            {
                //checked Email 
                Admin a = ctx.Admins.Where(x => x.Email == ad.Email).FirstOrDefault();
                if (ad.Name == null)
                {
                    ModelState.AddModelError(string.Empty, "Vui lòng điền vào tên tài khoản");
                    return View(ad);
                }
                else if (a != null)
                {
                    ModelState.AddModelError(string.Empty, "Email is existed !!!");
                    /* ViewBag.Message = string.Format("Error.\\nEmail is existed !!!\\nPlease enter again ^^");*/
                    return View(ad);
                }
                else
                {
                    if(rp_pass == null)
                    {
                        ModelState.AddModelError(string.Empty, "Vui lòng nhập lại mật khẩu xác minh !!!!!");
                        return View(ad);
                    }
                    else if (ad.Password == rp_pass)
                    {
                        ctx.Admins.Add(ad);
                        ctx.SaveChanges();
                        return RedirectToAction("Login", new { id = true });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Your password and repeat password is not correct!!!!!");
                     /*   ViewBag.Message = string.Format("Error.\\nYour password and repeat password is not correct!!!\\nPlease regist again ^^");*/
                        return View(ad);
                    }
                }

            }
            else
            {
                return View(ad);
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}