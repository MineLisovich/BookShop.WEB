using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class BindingViewModel
    {
        public IEnumerable<Binding> Bindings { get; set; }
        public string serch { get; set; }
    }
}
