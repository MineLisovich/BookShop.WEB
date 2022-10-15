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
    public class AuthorsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public AuthorsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEAuthors(int Id)
        {
            var authors = Id == default ? new TheAuthors() : dataManager.TheAuthors.GetById(Id);
            return View(authors);
        }
        [HttpPost]
        public IActionResult AEAuthors(TheAuthors viewModel)
        {
            
               
                if (viewModel.FullName !=null)
                {
       
                    dataManager.TheAuthors.SaveTheAuthors(viewModel);
                    return RedirectToAction(nameof(HomeController.Authors), nameof(HomeController).CutController());
                }
            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(TheAuthors viewModel)
        {
            dataManager.TheAuthors.DeleteTheAuthors(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Authors), nameof(HomeController).CutController());
        }
    }
}
