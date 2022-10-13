using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class FormatViewModel
    {
        public IEnumerable<Format> Formats { get; set; }
        public string serch { get; set; } 
    }
}
