using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class ImporterViewModel
    {
        public IEnumerable<Importer> Importers { get; set; }
        public string serch { set; get; }
    }
}
