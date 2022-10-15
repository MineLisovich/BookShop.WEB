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
    public class FormatsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public FormatsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEFormat(int Id)
        {
            var format = Id == default ? new Format() : dataManager.Format.GetById(Id);
            return View(format);
        }
        [HttpPost]
        public IActionResult AEFormat(Format viewModel)
        {


            if (viewModel.NameFormat != null)
            {

                dataManager.Format.SaveFormat(viewModel);
                return RedirectToAction(nameof(HomeController.Format), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(Format viewModel)
        {
            dataManager.Format.DeleteFormat(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Format), nameof(HomeController).CutController());
        }
    }
}
