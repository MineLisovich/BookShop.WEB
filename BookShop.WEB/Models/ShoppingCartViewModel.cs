using BookShop.WEB.DataBase.Entities;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCart { get; set; }
        public string serch { get; set; }
    }
}
