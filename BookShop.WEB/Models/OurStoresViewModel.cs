using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class OurStoresViewModel
    {
        public IEnumerable<OurStores>  OurStores { get; set; }
        public string serch { get; set; }
    }
}
