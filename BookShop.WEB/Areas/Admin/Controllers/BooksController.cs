using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookShop.WEB.DataBase;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace BookShop.WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BooksController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public BooksController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEBooks(int Id)
        {
            var books = Id == default ? new Books() : dataManager.Books.GetById(Id);
            var authors = dataManager.TheAuthors.GetById(books.TheAuthorsid);
            var binding = dataManager.Binding.GetById(books.Bindingid);
            var format = dataManager.Format.GetById(books.Formatid);
            var ganres = dataManager.Ganres.GetById(books.Ganresid);
            var importer = dataManager.Importer.GetById(books.Importerid);
            var publisher = dataManager.Publisher.GetById(books.Publisherid);

            SelectList FormatList = new SelectList(_db.Format, "NameFormat", "NameFormat");
            ViewBag.FormatList = FormatList;
            SelectList BindingList = new SelectList(_db.Binding, "NameBinding", "NameBinding");
            ViewBag.BindingList = BindingList;
            SelectList AuthorsList = new SelectList(_db.TheAuthors, "FullName", "FullName");
            ViewBag.AuthorsList = AuthorsList;  
            SelectList GanresList = new SelectList(_db.Ganres, "NameGanre", "NameGanre");
            ViewBag.GanresList = GanresList;
            SelectList ImporterList = new SelectList(_db.Importer, "FullNameImporter", "FullNameImporter");
            ViewBag.ImporterList = ImporterList;
            SelectList PublisherList = new SelectList(_db.Publisher, "ShortNamePublisher", "ShortNamePublisher");
            ViewBag.PublisherList = PublisherList;


            return View(books);
        }
        [HttpPost]
        public IActionResult AEBooks(Books viewModel, IFormFile TitleImage)
        {
            
                viewModel.TitleNameImage = TitleImage.FileName;
                
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/bookTitle", TitleImage.FileName), FileMode.Create))
                {
                    TitleImage.CopyTo(stream);
                }
                var authors = dataManager.TheAuthors.GetByName(viewModel.TheAuthors.FullName);
                var binding = dataManager.Binding.GetByName(viewModel.Binding.NameBinding);
                var format = dataManager.Format.GetByName(viewModel.Format.NameFormat);
                var ganres = dataManager.Ganres.GetByName(viewModel.Ganres.NameGanre);
                var importer = dataManager.Importer.GetByName(viewModel.Importer.FullNameImporter);
                var publisher = dataManager.Publisher.GetByName(viewModel.Publisher.ShortNamePublisher);
                if (authors !=null && binding !=null && format !=null && ganres != null && importer !=null 
                    && publisher != null && TitleImage.FileName != null && viewModel.AgeLimit !=0 && viewModel.BookDescription!=null 
                    && viewModel.BookWeight !=0 && viewModel.NameBook !=null && viewModel.NumberPages!=0)
                {
                    viewModel.TheAuthorsid = authors.Id;    
                    viewModel.Bindingid = binding.Id;
                    viewModel.Formatid = format.Id;
                    viewModel.Ganresid = ganres.Id;
                    viewModel.Importerid = importer.Id;
                    viewModel.Publisherid = publisher.Id;
                    viewModel.DateAddSite = DateTime.Now;
                    dataManager.Books.SaveBooks(viewModel);
                    return RedirectToAction(nameof(HomeController.Books), nameof(HomeController).CutController());
                }
            
            return View(viewModel); 
        }

        [HttpGet]
        public ActionResult Delete(Books viewModel)
        {
            dataManager.Books.DeleteBooks(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Books), nameof(HomeController).CutController());
        }

    }
}
