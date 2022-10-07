using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Переплёт"
    public class Binding
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите переплёт книги")]
        public string NameBinding { get; set; }
    }
}
