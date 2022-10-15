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
    public class PublishersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public PublishersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEPublisher(int Id)
        {
            var publisher = Id == default ? new Publisher() : dataManager.Publisher.GetById(Id);
            return View(publisher);
        }
        [HttpPost]
        public IActionResult AEPublisher(Publisher viewModel)
        {


            if (viewModel.ShortNamePublisher != null && viewModel.FullNamePublisher !=null && viewModel.AddressPublisher!=null)
            {

                dataManager.Publisher.SavePublisher(viewModel);
                return RedirectToAction(nameof(HomeController.Publisher), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(Publisher viewModel)
        {
            dataManager.Publisher.DeletePublisher(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Publisher), nameof(HomeController).CutController());
        }
    }
}
