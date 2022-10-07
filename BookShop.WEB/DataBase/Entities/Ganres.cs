using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Жанры"
    public class Ganres
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите жанр")]
        public string NameGanre { get; set; }
    }
}
