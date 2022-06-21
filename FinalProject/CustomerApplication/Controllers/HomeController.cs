﻿using CustomerApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace CustomerApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StoreContext ctx = new StoreContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View ();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ProductsCard()
        {
            return View();
        }

        public IActionResult Products()
        {
            ProductRepository rep = new ProductRepository();
            List<Product> lst = rep.getAllProducts();
            //passing data to view
            return View(lst); ;
        }

    
    public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}