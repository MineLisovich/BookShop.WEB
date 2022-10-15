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
    public class BindingsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public BindingsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEBinding(int Id)
        {
            var binding = Id == default ? new Binding() : dataManager.Binding.GetById(Id);
            return View(binding);
        }
        [HttpPost]
        public IActionResult AEBinding(Binding viewModel)
        {


            if (viewModel.NameBinding != null )
            {

                dataManager.Binding.SaveBinding(viewModel);
                return RedirectToAction(nameof(HomeController.Binding), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(Binding viewModel)
        {
            dataManager.Binding.DeleteBinding(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Binding), nameof(HomeController).CutController());
        }
    }
}
