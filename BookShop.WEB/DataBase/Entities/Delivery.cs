using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Доставка заказа"
    public class Delivery
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

        [Required]
        public string AdressDelivery { get; set; }
        [Required]
        public string PhoneUser { get; set; }
        [Required]
        public DateTime DataDlivery { get; set; }
    }
}
