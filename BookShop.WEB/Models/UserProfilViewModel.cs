using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using BookShop.WEB.DataBase.Entities;

namespace BookShop.WEB.Models
{
    public class UserProfilViewModel
    {
        public IEnumerable<ShoppingCart> shoppingCarts { get; set; }
        public Pickup Pickup { get; set; }
        public Delivery Delivery { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public OurStores OurStores { get; set; }
        public int FinalPrice { get; set; }
    }
}
