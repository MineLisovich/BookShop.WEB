using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Наши магазины" (эта таблица используется для выбора места самовывоза книги)
    public class OurStores
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Выберите адрес магазина")]
        public string AdressStore { get; set; }
    }
}
