using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Издатели"
    public class Publisher
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите краткое наименование")]
        public string ShortNamePublisher { get; set; }
        [Required(ErrorMessage = "Введите полное наименование")]
        public string FullNamePublisher { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        public string AddressPublisher { get; set; }
    }
}
