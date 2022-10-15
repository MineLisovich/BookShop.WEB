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
    public class ImportersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public ImportersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEImporter(int Id)
        {
            var importer = Id == default ? new Importer() : dataManager.Importer.GetById(Id);
            return View(importer);
        }
        [HttpPost]
        public IActionResult AEImporter(Importer viewModel)
        {


            if (viewModel.FullNameImporter != null && viewModel.AddressImpoter != null)
            {

                dataManager.Importer.SaveImporter(viewModel);
                return RedirectToAction(nameof(HomeController.Importer), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(Importer viewModel)
        {
            dataManager.Importer.DeleteImporter(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Importer), nameof(HomeController).CutController());
        }
    }
}
