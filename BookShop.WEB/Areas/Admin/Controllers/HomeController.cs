using Microsoft.AspNetCore.Mvc;
using BookShop.WEB.DataBase;
using BookShop.WEB.Models;
using System.Collections.Generic;
using BookShop.WEB.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;
using System.Xml.Linq;


namespace BookShop.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly DataManager dataManager;
        private readonly Context _db;
        public HomeController(DataManager dataManager, Context db, UserManager<IdentityUser> userMgr)
        {
            this.dataManager = dataManager;
            _db = db;
            userManager = userMgr;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Books(string serch)
        {
            IQueryable<Books> books = _db.Books.Include(b => b.Binding).Include(f => f.Format).Include(g => g.Ganres).Include(i => i.Importer).Include(p => p.Publisher).Include(t => t.TheAuthors);
            if (!String.IsNullOrEmpty(serch))
            {
                books = books.Where(p => p.NameBook.Contains(serch));
            }
            BooksViewModel viewModel = new BooksViewModel
            {
                Books = books.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Authors(string serch)
        {
            IQueryable<TheAuthors> authors = _db.TheAuthors;
            if (!String.IsNullOrEmpty(serch))
            {
                authors = authors.Where(s => s.FullName.Contains(serch));
            }
            TheAuthorsViewModel viewModel = new TheAuthorsViewModel
            {
                TheAuthors = authors.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Ganres(string serch)
        {
            IQueryable<Ganres> ganres = _db.Ganres;
            if (!String.IsNullOrEmpty(serch))
            {
                ganres = ganres.Where(s => s.NameGanre.Contains(serch));
            }
            GanreViewModel viewModel = new GanreViewModel
            {
                ganres = ganres.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Publisher(string serch)
        { 
            IQueryable <Publisher> publisher = _db.Publisher;
            if (!String.IsNullOrEmpty(serch))
            {
                publisher = publisher.Where(s => s.ShortNamePublisher.Contains(serch));
            }
            PublisherViewModel viewModel = new PublisherViewModel
            { 
                Publisher = publisher.ToList(),
                serch=serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Importer(string serch)
        {
            IQueryable<Importer> importers = _db.Importer;
            if (!String.IsNullOrEmpty(serch))
            {
                importers = importers.Where(s => s.FullNameImporter.Contains(serch));
            }
            ImporterViewModel viewModel = new ImporterViewModel
            {
                Importers = importers.ToList(), 
                serch= serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Binding(string serch)
        {
            IQueryable<Binding> binding = _db.Binding;
            if (!String.IsNullOrEmpty(serch))
            {
                binding = binding.Where(s=> s.NameBinding.Contains(serch)); 
            }
            BindingViewModel viewModel = new BindingViewModel
            {
                Bindings = binding.ToList(),
                serch=serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Format(string serch)
        {
            IQueryable<Format> formats = _db.Format;    
            if(!String.IsNullOrEmpty(serch))
            {
                formats = formats.Where(s=> s.NameFormat.Contains(serch));
            }
            FormatViewModel viewModel = new FormatViewModel
            { 
                Formats = formats.ToList(),
                serch=serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult OurStores(string serch)
        {
            IQueryable<OurStores> ourStores = _db.OurStores;
            if (!String.IsNullOrEmpty(serch))
            {
                ourStores = ourStores.Where(s => s.AdressStore.Contains(serch));
            }
            OurStoresViewModel viewModel = new OurStoresViewModel
            {
                OurStores = ourStores.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Users(string serch)
        {
            IEnumerable<IdentityUser> user = userManager.Users.ToList();
            if (!String.IsNullOrEmpty(serch))
            {
                user = user.Where(u => u.UserName.Contains(serch));
            }
            UserViewModel viewModel = new UserViewModel
            {
                user = user.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ShoppingCart(string serch)
        {
            IQueryable<ShoppingCart> shoppingCarts = _db.ShoppingCart.Include(b => b.Books).Include(u => u.User);
            if (!String.IsNullOrEmpty(serch))
            {
                shoppingCarts = shoppingCarts.Where(s=>s.User.UserName.Contains(serch));
            }
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCarts.ToList(),
                serch=serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Pickup(string serch)
        {
            IQueryable<Pickup> pickup = _db.Pickup.Include(u=>u.User).Include(o=>o.OurStores);
            if (!String.IsNullOrEmpty(serch))
            {
                pickup = pickup.Where(s => s.User.UserName.Contains(serch));
            }
            PickupViewModel viewModel = new PickupViewModel
            {
                Pickup = pickup.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delivery(string serch)
        {
            IQueryable<Delivery> deliveries = _db.Delivery.Include(u => u.User);
            if (!String.IsNullOrEmpty(serch))
            {
                deliveries = deliveries.Where(s => s.User.UserName.Contains(serch));
            }
            DeliveryViewModel viewModel = new DeliveryViewModel
            {
                Delivery = deliveries.ToList(),
                serch = serch
            };
            return View(viewModel);
        }
    }
}
