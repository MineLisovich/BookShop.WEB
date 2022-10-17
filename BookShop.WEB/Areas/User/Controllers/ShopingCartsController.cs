using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using BookShop.WEB.Service;
using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using System;

namespace BookShop.WEB.Areas.User.Controllers
{
    [Area("user")]   
    public class ShopingCartsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Context _db;
        UserManager<IdentityUser> _userManager;
        public ShopingCartsController (DataManager dataManager, IWebHostEnvironment webHostEnvironment, Context db, UserManager<IdentityUser> userManager)
        {
            this._dataManager = dataManager;
            this._webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager; 
        }
     public async Task<IActionResult> Add (int id)
     {
            var user = await _userManager.GetUserAsync(User);
            var books = _db.Books.FirstOrDefault(x => x.Id == id);
            ShoppingCart viewModel = new ShoppingCart()
            { 
                Booksid = books.Id,
                UserId = user.Id,
                TotalPrice = books.Price
            };
            if (viewModel.Booksid !=0 && viewModel.UserId != null)
            {
                _dataManager.ShoppingCart.SaveShoppingCart(viewModel);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
     }
        public IActionResult Delete (ShoppingCart viewModel)
        {
            _dataManager.ShoppingCart.DeleteShoppingCart(viewModel.Id);
            return RedirectToAction(nameof(Index), nameof(HomeController).CutController());
        }
    }
}
