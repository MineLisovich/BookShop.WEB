﻿using Microsoft.AspNetCore.Mvc;

namespace BookShop.WEB.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
