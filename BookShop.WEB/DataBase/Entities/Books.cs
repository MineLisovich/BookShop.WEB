using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace BookShop.WEB.DataBase.Entities
{
    //Таблица "Книги" (главная таблица)
    public class Books
    {
        [Required]// Валидация
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите наименование книги")]
        public string NameBook { get; set; }
        
        public TheAuthors TheAuthors { get; set; } //Связь с таблицей "Авторы"
        [Required]
        public int TheAuthorsid { get; set; }// FK ключ
        public Ganres Ganres { get; set; } //Связь с таблицей "Жанры"
        [Required]
        public int Ganresid { get; set; }// FK ключ
        [Required (ErrorMessage ="Введите описание книги")]
        public string BookDescription { get; set; }
        [Required (ErrorMessage ="Введите год издания")]
        public DateTime YearPublishing { get; set; }
        [Required (ErrorMessage ="Введите количество страниц")]
        public int NumberPages { get; set; }
        public Publisher Publisher { get; set; } //Связь с таблицей "Издатель"
        [Required]
        public int Publisherid { get; set; }// FK ключ
        [Required(ErrorMessage ="Введите стоимость")]
        public int Price { get; set; }
        public Binding Binding { get; set; }//Связь с таблицей "Переплёт книги"
        [Required]
        public int Bindingid { get; set; }// FK ключ

        public Format Format { get; set; }//Связь с таблицей "Формат книги"
        [Required]
        public int Formatid { get; set; }// FK ключ
        [Required(ErrorMessage ="Введите вес книги")]
        public int BookWeight   { get; set; }
        [Required(ErrorMessage ="Введите возрастное ограничение")]
        public int AgeLimit { get; set; }
        
        public Importer Importer { get; set; }//Связь с таблицей "Импортёр"
        [Required]
        public int Importerid { get; set; }// FK ключ
        
        public string TitleNameImage { get; set; }
        [Required(ErrorMessage ="Введите дату добавления на сайт")]
        public DateTime DateAddSite { get; set; }
    }
}
