using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class GanreViewModel
    {
        public IEnumerable<Ganres> ganres { get; set; }    
        public string serch { get; set; }
    }
}
