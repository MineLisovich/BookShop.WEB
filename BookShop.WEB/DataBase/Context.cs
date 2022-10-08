using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookShop.WEB.DataBase.Entities;


namespace BookShop.WEB.DataBase
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Binding> Binding { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Format> Format { get; set; }    
        public DbSet<Ganres> Ganres { get; set; }
        public DbSet<Importer> Importer { get; set; }
        public DbSet<OurStores> OurStores { get; set; }
        public DbSet <Pickup> Pickup { get; set; }
        public DbSet <Publisher> Publisher { get; set; }
        public DbSet <ShoppingCart> ShoppingCart { get; set; }
        public DbSet <TheAuthors> TheAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Заполнение таблицы "Авторы"
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            { 
                Id = 1,
                FullName = "Лев Николаевич Толстой"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 2,
                FullName = "Уильям Шекспир"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 3,
                FullName = "Джеймс Джойс"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 4,
                FullName = "Владимир Владимирович Набоков"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 5,
                FullName = "Фёдор Михайлович Достоевский"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 6,
                FullName = "Уильям Фолкнер"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 7,
                FullName = "Чарльз Диккенс"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 8,
                FullName = "Антон Павлович Чехов"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 9,
                FullName = "Гюстав Флобер"
            });
            builder.Entity<TheAuthors>().HasData(new TheAuthors
            {
                Id = 10,
                FullName = "Джейн Остин"
            });

            //Заполение Таблицы "Жанр"
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 1,
                NameGanre ="Детектив"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 2,
                NameGanre = "Фантастика"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 3,
                NameGanre = "Приключения"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 4,
                NameGanre = "Роман"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 5,
                NameGanre = "Научная книга"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 6,
                NameGanre = "Фольклор"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 7,
                NameGanre = "Юмор"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 8,
                NameGanre = "Поэзия, проза"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 9,
                NameGanre = "Детская книга"
            });
            builder.Entity<Ganres>().HasData(new Ganres
            {
                Id = 10,
                NameGanre = "Документальная литература"
            });

            // Заполение таблицы "Переплёт книги"
            builder.Entity<Binding>().HasData(new Binding 
            { 
                Id=1,
                NameBinding="Твёрдый переплёт"
            });
            builder.Entity<Binding>().HasData(new Binding
            {
                Id = 2,
                NameBinding = "Мягкий переплёт"
            });

            // Заполение таблицы "Формат книги"
            builder.Entity<Format>().HasData(new Format
            {
                Id=1,
                NameFormat= "Сверхкрупный — (84×108/8; 70×90/8)"
            });
            builder.Entity<Format>().HasData(new Format
            {
                Id = 2,
                NameFormat = "Крупный — (70×90/16; 75×90/16)"
            });
            builder.Entity<Format>().HasData(new Format
            {
                Id = 3,
                NameFormat = "Средний — (60×90/16; 84×108/32)"
            });
            builder.Entity<Format>().HasData(new Format
            {
                Id = 4,
                NameFormat = "Малый — (70×90/32; 70×108/32)"
            });
            builder.Entity<Format>().HasData(new Format
            {
                Id = 5,
                NameFormat = "Сверхмалый — (60×90/32)"
            });

            // Заполнение таблицы "Издатель"
            builder.Entity<Publisher>().HasData(new Publisher 
            { 
                Id=1,
                ShortNamePublisher="Эксмо",
                FullNamePublisher="ООО <<Издательство Эксмо>>",
                AddressPublisher="РФ, г.Москва, ул. Клары Цеткин 18,корп.5",
            });
            builder.Entity<Publisher>().HasData(new Publisher
            {
                Id = 2,
                ShortNamePublisher = "Аверсэв",
                FullNamePublisher = "ОДО <<Аверсэв>>",
                AddressPublisher = "РБ, г.Минск, ул. Олешева 1, офис 309",
            });
            builder.Entity<Publisher>().HasData(new Publisher
            {
                Id = 3,
                ShortNamePublisher = "Комильфо",
                FullNamePublisher = "ООО <<Комильфо>>",
                AddressPublisher = "РФ, г.Москва, Волгоградский Просп, д. 3-5",
            });
            builder.Entity<Publisher>().HasData(new Publisher
            {
                Id = 4,
                ShortNamePublisher = "АСТ",
                FullNamePublisher = "Творческое кооперативное объединение <<АСТ>>",
                AddressPublisher = "РФ, г.Москва, б-р Звёздный 21, стр.1",
            });
            builder.Entity<Publisher>().HasData(new Publisher
            {
                Id = 5,
                ShortNamePublisher = "Синдбад",
                FullNamePublisher = "ООО <<Издательсво Синдбад>>",
                AddressPublisher = "РФ, г.Москва, ул. Зубовский бульвар 13 стр.2",
            });

            // Заполение таблицы "Импортёр"
            builder.Entity<Importer>().HasData(new Importer
            {
                Id=1,
                FullNameImporter="ООО <<Приносим радость>>",
                postcode=220073,
                AddressImpoter= "РБ, г.Минск, ул. Скрыганова 14, каб. 36 ",
            });
            builder.Entity<Importer>().HasData(new Importer
            {
                Id = 2,
                FullNameImporter = "ООО <<Харвест>>",
                postcode = 220013,
                AddressImpoter = "РБ, г.Минск ул. Кульман 1/3-42",
            });

            //Заполнение таблицы "Книги"
            builder.Entity<Books>().HasData(new Books
            {
                Id = 1,
                NameBook = "Книга 1",
                TheAuthorsid = 1,
                Ganresid = 1,
                BookDescription = "Тут будет описание книги",
                YearPublishing = new DateTime(2022, 02, 22),
                NumberPages = 134,
                Publisherid = 1,
                Price = 12,
                Bindingid = 1,
                Formatid = 1,
                BookWeight = 456,
                AgeLimit = 12,
                Importerid = 1,   
                TitleNameImage ="Book1.jpg",
                DateAddSite= new DateTime(2022,10,08)
            }) ;
            // Заполение таблиц Asp net Identity
            // Заплнение таблицы "Роль пользователя"
            builder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = "666",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "333",
                Name = "user",
                NormalizedName = "USER"
            });

            //Заполение таблицы "Пользователи"
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            { 
                Id = "696",
                UserName="admin",
                NormalizedUserName="admin",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"admin"),
                SecurityStamp = string.Empty,
                Email= "bookshop@mail.ru",
                NormalizedEmail= "bookshop@mail.ru",
                EmailConfirmed = true
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "393",
                UserName = "user",
                NormalizedUserName = "user",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "user1"),
                SecurityStamp = string.Empty,
                Email = "user@mail.ru",
                NormalizedEmail = "user@mail.ru",
                EmailConfirmed = true
            });

            // Свзять роли и пользователя
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "666",
                UserId="696",
            });// admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "333",
                UserId = "393",
            });//user

            //Заполнение таблицы "Корзина"
            builder.Entity<ShoppingCart>().HasData(new ShoppingCart
            {
                Id = 1,
                UserId ="393",
                Booksid = 1,
                TotalPrice = 12
            });

            // Заполнение таблицы "Наши Магазины"
            builder.Entity<OurStores>().HasData(new OurStores
            {
                Id=1,
                AdressStore="Г.Минск, Ул. Ландыши 1"
            });

            //Заполнение таблицы "Самовывоз"
            builder.Entity<Pickup>().HasData(new Pickup
            {
                Id=1,
                UserId="393",
                NameBook="Book1",
                Price=12,
                OurStoresid=1
            });

            //Заполнение таблицы "Доставка"
            builder.Entity<Delivery>().HasData(new Delivery
            {
                Id =1,
                UserId="393",
                NameBook = "Book1",
                Price = 12,
                AdressDelivery="г.Минск, ул.Лиловая 43, кв 32",
                PhoneUser="+375(29)454-45-55"
            });

        }

    }
}
