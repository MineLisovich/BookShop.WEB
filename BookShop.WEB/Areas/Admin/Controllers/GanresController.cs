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
    public class GanresController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly Context _db;

        public GanresController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, Context db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }
        [HttpGet]
        public IActionResult AEGanres(int Id)
        {
            var ganres = Id == default ? new Ganres() : dataManager.Ganres.GetById(Id);
            return View(ganres);
        }
        [HttpPost]
        public IActionResult AEGanres(Ganres viewModel)
        {


            if (viewModel.NameGanre != null)
            {

                dataManager.Ganres.SaveGanres(viewModel);
                return RedirectToAction(nameof(HomeController.Ganres), nameof(HomeController).CutController());
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(Ganres viewModel)
        {
            dataManager.Ganres.DeleteGanres(viewModel.Id);
            return RedirectToAction(nameof(HomeController.Ganres), nameof(HomeController).CutController());
        }
    }
}
