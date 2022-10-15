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
    public class OurStoresController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public OurStoresController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEOurStores(int Id)
        {
            var ourstore = Id == default ? new OurStores() : dataManager.OurStores.GetById(Id);
            return View(ourstore);
        }
        [HttpPost]
        public IActionResult AEOurStores(OurStores viewModel)
        {


            if (viewModel.AdressStore != null)
            {

                dataManager.OurStores.SaveOurStores(viewModel);
                return RedirectToAction(nameof(HomeController.OurStores), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(OurStores viewModel)
        {
            dataManager.OurStores.DeleteOurStores(viewModel.Id);
            return RedirectToAction(nameof(HomeController.OurStores), nameof(HomeController).CutController());
        }
    }
}
