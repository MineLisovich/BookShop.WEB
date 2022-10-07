using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Формат книги"
    public class Format
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите формат книги")]
        public string NameFormat { get; set; }
    }
}
