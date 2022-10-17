using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using BookShop.WEB.DataBase.Entities;

namespace BookShop.WEB.Models
{
    public class UserProfilViewModel
    {
        public IEnumerable<ShoppingCart> shoppingCarts { get; set; }
        public IEnumerable<Pickup> pickups { get; set; }
        public IEnumerable<Delivery> delivery { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public int FinalPrice { get; set; }
    }
}
