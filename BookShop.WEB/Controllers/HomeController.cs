using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.Models;
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
            IQueryable<Books> books = _db.Books.Include(b => b.Binding).Include(f => f.Format).Include(g => g.Ganres).Include(i => i.Importer).Include(p => p.Publisher).Include(t => t.TheAuthors);
            
            BooksViewModel viewModel = new BooksViewModel
            {
                Books = books.ToList(),
            };
            return View(viewModel);
        }

      public IActionResult Products(string serch, int? author, int? ganre, int? publisher)
        {
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

            BooksViewModel viewModel = new BooksViewModel 
            {
                Books = books.ToList(),
                TheAuthorstList = new SelectList(authors, "Id", "FullName"),
                GanrestList = new SelectList(ganres, "Id", "NameGanre"),
                PublishertList = new SelectList(publishers, "Id", "ShortNamePublisher"),
                serch = serch
            
            };
            return View(viewModel);
        }
        public IActionResult Contacts() 
        { 
            return View();
        }

        [HttpGet]
        public IActionResult ProductPage(int Id)
        {
            var books = Id == default ? new Books() : dataManager.Books.GetById(Id);
            var authors = dataManager.TheAuthors.GetById(books.TheAuthorsid);
            var binding = dataManager.Binding.GetById(books.Bindingid);
            var format = dataManager.Format.GetById(books.Formatid);
            var ganres = dataManager.Ganres.GetById(books.Ganresid);
            var importer = dataManager.Importer.GetById(books.Importerid);
            var publisher = dataManager.Publisher.GetById(books.Publisherid);
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
