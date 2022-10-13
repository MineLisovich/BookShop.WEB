using BookShop.WEB.DataBase.Entities;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class PickupViewModel
    {
        public IEnumerable<Pickup> Pickup { get; set; }
        public string serch { get; set; }
    }
}
