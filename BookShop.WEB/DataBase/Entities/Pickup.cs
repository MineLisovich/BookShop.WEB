using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Самовывоз"
    public class Pickup
    {
        [Required]
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string NameBook { get; set; }
        [Required]
        public int Price { get; set; }
        public OurStores OurStores { get; set; }
        [Required]
        public int OurStoresid { get; set; }
        [Required]
        public DateTime DateIssueOrder { get; set; }
    }
}
