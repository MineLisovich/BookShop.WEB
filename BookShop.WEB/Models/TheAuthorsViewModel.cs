using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class TheAuthorsViewModel
    {
        public IEnumerable<TheAuthors> TheAuthors { get; set; }
        public string serch { get; set; }
    }
}
