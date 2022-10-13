using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.Models
{
    public class UserViewModel
    {
        public IEnumerable<IdentityUser> user { get; set; }
        public string serch { get; set; }
    }
}
