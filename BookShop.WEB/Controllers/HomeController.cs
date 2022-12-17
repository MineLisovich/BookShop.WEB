using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.Models;
using BookShop.WEB.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.WEB.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DataManager dataManager;
        private readonly Context _db;
        public HomeController(DataManager dataManager, Context db, UserManager<IdentityUser> userMgr, RoleManager<IdentityRole> roleManager)
        {
            this.dataManager = dataManager;
            _db = db;
            userManager = userMgr;
            this.roleManager = roleManager;
        }

        public async Task <IActionResult> Index()
        {
            BooksViewModel viewModel = new BooksViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                viewModel.UserRoles = role;
            }
         
            

            IQueryable<Books> books = _db.Books.Include(b => b.Binding).Include(f => f.Format).Include(g => g.Ganres).Include(i => i.Importer).Include(p => p.Publisher).Include(t => t.TheAuthors);


            viewModel.Books = books.ToList();
               viewModel.IdentityUser = user;
                
           
            return View(viewModel);
        }

      public async Task <IActionResult> Products(string serch, int? author, int? ganre, int? publisher)
        {
            BooksViewModel viewModel = new BooksViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                viewModel.UserRoles = role;
            }
            IQueryable<Books> books = _db.Books.Include(b => b.Binding).Include(f => f.Format).Include(g => g.Ganres).Include(i => i.Importer).Include(p => p.Publisher).Include(t => t.TheAuthors);
            if (!String.IsNullOrEmpty(serch)) { books = books.Where(n => n.NameBook.Contains(serch)); }
            if (author !=null && author != 0) { books = books.Where(a => a.TheAuthorsid == author); }
            if (ganre !=null && ganre != 0) { books = books.Where(g => g.Ganresid == ganre); }
            if (publisher !=null && publisher !=0) { books = books.Where(p => p.Publisherid == publisher); }

            List<TheAuthors> authors = _db.TheAuthors.ToList();
            List<Ganres> ganres = _db.Ganres.ToList();
            List<Publisher> publishers = _db.Publisher.ToList();
            authors.Insert(0, new TheAuthors { FullName = "Выберите Автора", Id = 0 });
            ganres.Insert(0, new Ganres { NameGanre = "Выберите жанр", Id = 0 });
            publishers.Insert(0, new Publisher { ShortNamePublisher = "Выберите Издателя", Id = 0 });



            viewModel.Books = books.ToList();
            viewModel.TheAuthorstList = new SelectList(authors, "Id", "FullName");
            viewModel.GanrestList = new SelectList(ganres, "Id", "NameGanre");
            viewModel.PublishertList = new SelectList(publishers, "Id", "ShortNamePublisher");
                viewModel.serch = serch;
            viewModel.IdentityUser = user;

            return View(viewModel);
        }
        [HttpGet]
        public async Task <IActionResult> Contacts() 
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                viewModel.UserRoles = role;
            }
            viewModel.IdentityUser = user;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Contacts(FeedbackViewModel viewModel)
        {
            EmailService emailService = new EmailService();
            if (viewModel.Email !=null && viewModel.Message != null)
            {
                await emailService.SendEmailAsync("vita.bu@mail.ru", viewModel.Email, viewModel.Message);
                return RedirectToAction(nameof(HomeController.MeesageSent), nameof(HomeController).CutController());
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task <IActionResult> ProductPage(int Id)
        {
            BooksViewModel viewModel = new BooksViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                viewModel.UserRoles = role;
            }
            viewModel.IdentityUser = user;
            IQueryable<Books> books = _db.Books.Include(a => a.TheAuthors).Include(b => b.Binding).Include(f => f.Format).Include(g => g.Ganres).Include(i => i.Importer).Include(p => p.Publisher).Where(b => b.Id == Id);
            viewModel.Books = books;
            return View(viewModel); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> MeesageSent()
        {
            BooksViewModel viewModel = new BooksViewModel();
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                viewModel.UserRoles = role;
            }
            viewModel.IdentityUser = user;
            return View(viewModel);
        }
    }
}
