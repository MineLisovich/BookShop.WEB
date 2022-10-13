using BookShop.WEB.DataBase.Entities;
using System.Collections.Generic;

namespace BookShop.WEB.Models
{
    public class DeliveryViewModel
    {
        public IEnumerable<Delivery> Delivery { get; set; } 
        public string serch { get; set; }
    }
}
