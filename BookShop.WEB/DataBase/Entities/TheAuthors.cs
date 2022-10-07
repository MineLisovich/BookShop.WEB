using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookShop.WEB.DataBase.Entities
{
    // Таблица "Авторы"
    public class TheAuthors
    {
        [Required] //Валидация
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите ФИО")]
        public string FullName { get; set; }
    }
}
