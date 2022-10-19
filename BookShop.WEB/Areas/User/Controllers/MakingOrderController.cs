using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using BookShop.WEB.Service;
using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using System;
using BookShop.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.WEB.Areas.User.Controllers
{
    [Area("user")]
    public class MakingOrderController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Context _db;
        UserManager<IdentityUser> _userManager;
        public MakingOrderController(DataManager dataManager, IWebHostEnvironment webHostEnvironment, Context db, UserManager<IdentityUser> userManager)
        {
            this._dataManager = dataManager;
            this._webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> MakingOrder()
        {
            var user = await _userManager.GetUserAsync(User);
            IQueryable<ShoppingCart> shoppingCarts = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User);
            var FinalPrise = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where(u => u.UserId == user.Id).Sum(fp => fp.TotalPrice);
            SelectList OurStoresList = new SelectList(_db.OurStores, "AdressStore", "AdressStore");
            ViewBag.OurStoresList = OurStoresList;
            UserProfilViewModel viewModel = new UserProfilViewModel
            {
                shoppingCarts = shoppingCarts.ToList(),
                IdentityUser = user,
                FinalPrice = FinalPrise,
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> MakingOrderPickup(UserProfilViewModel model)
        {
            Pickup viewModel = new Pickup();
            var user = await _userManager.GetUserAsync(User);
            var shoppingCart = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where(u => u.UserId == user.Id).ToList();
            var FinalPrise = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where(u => u.UserId == user.Id).Sum(fp => fp.TotalPrice);
            var OurStores = _dataManager.OurStores.GetByName(model.OurStores.AdressStore);

            if (shoppingCart != null)
            {
                for (int i = 0; i < shoppingCart.Count(); i++)
                {

                    viewModel.UserId = shoppingCart[i].UserId;
                    viewModel.NameBook = shoppingCart[i].Books.NameBook;
                    viewModel.Price = FinalPrise;
                    viewModel.OurStoresid = OurStores.Id;
                    viewModel.DateIssueOrder = model.Pickup.DateIssueOrder;

                    _dataManager.Pickup.SavePickup(viewModel);
                }

                var deleteShoppingCartQuery = from s in shoppingCart select s;
                foreach (ShoppingCart SC in deleteShoppingCartQuery)
                {
                    _db.ShoppingCart.Remove(SC);
                }
                _db.SaveChanges();
                return RedirectToAction("OrderProcessed", "Home");
            }
            else
                return RedirectToAction("MakingOrder", "MakingOrder");
        }
        [HttpPost]
        public async Task<IActionResult> MakingOrderDelivery(UserProfilViewModel model)
        {
            Delivery viewModel = new Delivery();
            var user = await _userManager.GetUserAsync(User);
            var shoppingCart = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where(u => u.UserId == user.Id).ToList();
            var FinalPrise = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User).Where(u => u.UserId == user.Id).Sum(fp => fp.TotalPrice);
            if (shoppingCart != null && model.Delivery.AdressDelivery !=null && model.Delivery.PhoneUser != null)
            {
               
                for (int i = 0; i < shoppingCart.Count(); i++)
                {



                    viewModel.UserId = shoppingCart[i].UserId;
                    viewModel.NameBook = shoppingCart[i].Books.NameBook;
                    viewModel.Price = FinalPrise;
                    viewModel.AdressDelivery = model.Delivery.AdressDelivery;
                    viewModel.PhoneUser = model.Delivery.PhoneUser;
                    viewModel.DataDlivery = model.Delivery.DataDlivery;
                    
                    _dataManager.Delivery.SaveDelivery(viewModel);
                }
                var deleteShoppingCartQuery = from s in shoppingCart select s;
                foreach (ShoppingCart SC in deleteShoppingCartQuery)
                {
                    _db.ShoppingCart.Remove(SC);
                }
                _db.SaveChanges();
                return RedirectToAction("OrderProcessed", "Home");
            }
            else
                return RedirectToAction("MakingOrder", "MakingOrder");
        }
    }
}