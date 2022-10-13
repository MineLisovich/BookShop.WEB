using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class PublisherViewModel
    {
        public IEnumerable<Publisher> Publisher { get; set; }
        public string serch { get; set; }
    }
}
