using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Корзина покупателей" 
    public class ShoppingCart
    {
        [Required]// Валидация
        public int Id { get; set; }
        public IdentityUser User { get; set; }  
        [Required]
        public string UserId { get; set; }
        public Books Books { get; set; }
        [Required]
        public int Booksid { get; set; }
        [Required]
        public int TotalPrice   { get; set; }
    }
}
