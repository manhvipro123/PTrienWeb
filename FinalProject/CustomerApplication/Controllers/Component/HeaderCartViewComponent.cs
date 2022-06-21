/*using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace CustomerApplication.Controllers.Component
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<ItemCart> items = null;
            var cart = HttpContext.Session.GetString("giohang");
            return View(cart);
        }
    }
}
*/