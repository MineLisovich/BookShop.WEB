using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.Models;

namespace BookShop.WEB.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly Context _db;
        private readonly DataManager _dataManager;
        UserManager<IdentityUser> _userManager;
        public HomeController (Context db, DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _db = db;
            this._dataManager = dataManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            IQueryable<ShoppingCart> shoppingCarts = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User);
            var FinalPrise = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where (u=>u.UserId == user.Id).Sum(fp => fp.TotalPrice);
            UserProfilViewModel viewModel = new UserProfilViewModel
            {
                shoppingCarts = shoppingCarts.ToList(),
                IdentityUser = user,
                FinalPrice = FinalPrise,
            };
            return View(viewModel);
        }
        public IActionResult OrderProcessed()
        { 
            return View();
        }
    }
}
