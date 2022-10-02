using Microsoft.AspNetCore.Mvc;

namespace BookShop.WEB.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
