using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Имортёр"
    public class Importer
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите полное наименование")]
        public string FullNameImporter { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        public string AddressImpoter { get; set; }
        [Required (ErrorMessage ="Введите почтовый индекс")]
        public int postcode { get; set; }
    }
}
