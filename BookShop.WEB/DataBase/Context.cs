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
                NameBook = "Война и мир (в 2 томах)",
                TheAuthorsid = 1,
                Ganresid = 4,
                BookDescription = "Жизнь, творческий путь, идейные искания Л.Н.Толстого по-прежнему увлекают умы наших современников, которые пытаются понять саму сущность творчества писателя и его учения.\"Война и мир\" - вершина творчества Л.Н.Толстого, как никакое другое произведение писателя отражает глубину его мироощущения и философии. Эта книга из разряда вечных, потому что она обо всем - о жизни и смерти, о любви и чести, о мужестве и героизме, о славе и подвиге, о войне и мире. Самый известный во всем мире роман гениального писателя вот уже третье столетие заставляет читателей сопереживать героям произведения. Роман о русской душе, о русском укладе жизни, о вечных вопросах, которые приходится решать каждому человеку наедине с собой. Все жизненные перипетии героев, происходящие на фоне исторических событий, произошедших в начале ХIХ века с Россией, на фоне кровавых событий войны 1812 года, обретают емкий философский смысл. Роман по глубине и охвату событий до сих пор стоит на первом месте во всей мировой...",
                YearPublishing = new DateTime(2014, 02, 22),
                NumberPages = 1406,
                Publisherid = 1,
                Price = 25,
                Bindingid = 1,
                Formatid = 3,
                BookWeight = 1020,
                AgeLimit = 12,
                Importerid = 1,   
                TitleNameImage = "lev_tolstoj_vojna_i_mir.jpg",
                DateAddSite= new DateTime(2022,10,08)
            }) ;

            builder.Entity<Books>().HasData(new Books
            {
                Id = 2,
                NameBook = "Анна Каренина",
                TheAuthorsid = 1,
                Ganresid = 4,
                BookDescription = "\"Анна Каренина\" – лучший роман о женщине, написанный в XIX веке. По словам Ф. М. Достоевского, \"Анна Каренина\" поразила современников \"не только вседневностью содержания, но и огромной психологической разработкой души человеческой, страшной глубиной и силой\". Уже к началу 1900-х годов роман Толстого был переведен на многие языки мира, а в настоящее время входит в золотой фонд мировой литературы.",
                YearPublishing = new DateTime(2012, 02, 22),
                NumberPages = 864,
                Publisherid = 2,
                Price = 15,
                Bindingid = 1,
                Formatid = 3,
                BookWeight = 571,
                AgeLimit = 16,
                Importerid = 1,
                TitleNameImage = "Lev_Tolstoy_Anna__Karen__ina.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id= 3,
                NameBook = "Детство. Отрочество. Юность",
                TheAuthorsid =1,
                Ganresid =8,
                BookDescription= "Повесть \"Детство\", впервые опубликованная в 1852 году в журнале \"Современник\", стала литературным дебютом Л. Н. Толстого, выдающегося русского писателя и мыслителя. Опираясь на детские воспоминания и дневниковые записи, Толстой, однако, писал не автобиографию и не мемуары. Автор пытался раскрыть универсальные законы развития человеческой души, ее загадочную изменчивую \"диалектику\", \"высказать такие тайны, которые нельзя сказать простым словом\", что как раз и составляет главную цель искусства, как считал автор. Впоследствии повесть \"Детство\" вместе с \"Отрочеством\" (1852-1854) и \"Юностью\" (1855-1857) соединились в трилогию и стали \"не только копилкой будущих литературных замыслов, но и некой абсолютной точкой на пути, раз и навсегда открытым континентом на карте толстовского мира\" (И. Н. Сухих).",
                YearPublishing=new DateTime(2022, 02,22),
                NumberPages=416,
                Publisherid = 3,
                Price=24,
                Bindingid=1,
                Formatid=3,
                BookWeight=322,
                AgeLimit=12,
                Importerid=1,
                TitleNameImage= "lev_tolstoj_otchestvo.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id =4,
                NameBook = "Ромео и Джульетта. Гамлет",
                TheAuthorsid =2,
                Ganresid =8,
                BookDescription = "В книгу вошли произведения У. Шекспира, которые изучаются в школе. \"Ромео и Джульетта\" – трагедия, рассказывающая о любви юноши и девушки из двух враждующих старинных родов – Монтекки и Капулетти, и одна из самых знаменитых пьес в мировой литературе \"Гамлет\".",
                YearPublishing = new DateTime(2020, 02, 22),
                NumberPages =352,
                Publisherid =1,
                Price =15,
                Bindingid =1,
                Formatid =3,
                BookWeight =340,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "shekspir_romeo_djyletta_gamlet.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 5,
                NameBook = "Преступление и наказание",
                TheAuthorsid =5,
                Ganresid =4,
                BookDescription = "Одно из \"краеугольных\" произведений русской и мировой литературы, включенный во все школьные и университетские программы, неоднократно экранизированный роман Достоевского \"Преступление и наказание\" ставит перед читателем важнейшие нравственно-мировоззренческие вопросы – о вере, совести, грехе и об искуплении через страдание. Опровержение преступной \"идеи-страсти\", \"безобразной мечты\", завладевшей умом Родиона Раскольникова в самом \"умышленном\" и \"фантастическом\" городе на свете, составляет основное содержание этой сложнейшей, соединившей в себе несколько различных жанров книги. Задуманный как \"психологический отчет одного преступления\", роман Достоевского предстал перед читателем грандиозным художественно-философским исследованием человеческой природы, христианской трагедией о смерти и воскресении души.",
                YearPublishing = new DateTime(2019, 02, 22),
                NumberPages =608,
                Publisherid =4,
                Price =14,
                Bindingid =1,
                Formatid =3,
                BookWeight =430,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "dostoevski_prestyplenie_nakazanie.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 6,
                NameBook = "Идиот",
                TheAuthorsid =5,
                Ganresid =4,
                BookDescription = "\"Главная идея... – писал Ф. М. Достоевский о своем романе \"Идиот\", – изобразить положительно-прекрасного человека. Труднее этого нет ничего на свете...\" Не для того ли писатель явил миру \"князя-Христа\", чтобы мы не забывали: \"Страдание есть главнейший и, может быть, единственный закон бытия всего человечества\".\r\n\r\nКаждое новое поколение по-своему воспринимает классику и пытается дать собственные ответы на вечные вопросы бытия. Об этом свидетельствуют и известные экранизации романа, его сценические версии. В России запоминающиеся образы князя Мышкина создали Ю. Яковлев, И. Смоктуновский, Е. Миронов.",
                YearPublishing = new DateTime(2012, 02, 22),
                NumberPages =640,
                Publisherid = 1,
                Price =15,
                Bindingid =1,
                Formatid =3,
                BookWeight =450,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "dostoevski_idiot.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 7,
                NameBook = "Братья Карамазовы",
                TheAuthorsid =5,
                Ganresid =4,
                BookDescription = "Последний, самый объемный и один из наиболее известных романов Ф. М. Достоевского обращает читателя к вневременным нравственно-философским вопросам о грехе, воздаянии, сострадании и милосердии. Книга, которую сам писатель определил как \"роман о богохульстве и опровержении его\", явилась попыткой \"решить вопрос о человеке\", \"разгадать тайну\" человека, что, по Достоевскому, означало \"решить вопрос о Боге\". Сквозь призму истории провинциальной семьи Карамазовых автор повествует об извечной борьбе Божественного и дьявольского в человеческой душе. Один из самых глубоких в мировой литературе опытов отражения христианского сознания, \"Братья Карамазовы\" стали в ХХ веке объектом парадоксальных философских и психоаналитических интерпретаций.",
                YearPublishing = new DateTime(2013, 02, 22),
                NumberPages =832,
                Publisherid = 1,
                Price =15,
                Bindingid =1,
                Formatid =3,
                BookWeight =560,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "dostoevski_bratya_karamazobi.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 8,
                NameBook = "Каштанка",
                TheAuthorsid =8,
                Ganresid =3,
                BookDescription = "В книгу вошли известнейшие и всеми любимые рассказы великого русского писателя Антона Павловича Чехова: \"Каштанка\", \"Пересолил\", \"Лошадиная фамилия\", \"Толстый и тонкий\" и другие. Чехов умел сочетать весёлое и грустное, и удивительно проникновенно говорить о самых обыкновенных вещах. Каждый его рассказ – целый мир, который умещается всего на нескольких страницах.",
                YearPublishing = new DateTime(2016, 02, 22),
                NumberPages =128,
                Publisherid =1,
                Price =9,
                Bindingid =1,
                Formatid =3,
                BookWeight =200,
                AgeLimit =6,
                Importerid =1,
                TitleNameImage = "chehov_kashtanka.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 9,
                NameBook = "Палата №6",
                TheAuthorsid =8,
                Ganresid =3,
                BookDescription = "Где та грань, которая отделяет здорового человека от больного, особенно если речь идет о нервных заболеваниях, ведь избежать нервные потрясения или перегрузки практически невозможно? Антон Чехов будучи сам врачом во многих своих произведениях рассказывает истории людей, незаметно переходящих эту грань, людей, которых убивает рутина, серые будни, и будучи чрезвычайно чувствительными и слабыми они ломаются под давлением обыденности и неспособности что-то противопоставить ей.",
                YearPublishing = new DateTime(2012, 02, 22),
                NumberPages =352,
                Publisherid =1,
                Price =9,
                Bindingid =2,
                Formatid =4,
                BookWeight =170,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "chehov_palata6.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 10,
                NameBook = "Вишневый сад",
                TheAuthorsid =8,
                Ganresid =8,
                BookDescription = "Драматургия искусство особое. Как известно, современники Чехова в восприятии его пьес разделились на два лагеря. Горячие поклонники Художественного театра наталкивались на вежливое равнодушие или откровенную неприязнь даже тех, кто был весьма расположен к Чехову-прозаику. \"Чехов несомненный талант, но пьесы его плохие. В них не решаются вопросы, нет содержания\", не раз повторял в беседах Л. Толстой. \"Пьесы его далеко не лучшее из написанного им...\" говорил И. Бунин. В XX веке многое изменилось. С развитием режиссерского театра драма как текст утратила свое значение она живет и умирает в спектакле. И только немногие пьесы наверное, они и называются классикой необходимо не только видеть на сцене, но и читать.",
                YearPublishing = new DateTime(2021, 02, 22),
                NumberPages =320,
                Publisherid =2,
                Price =15,
                Bindingid =1,
                Formatid =3,
                BookWeight =275,
                AgeLimit =12,
                Importerid =2,
                TitleNameImage = "chehov_vishevi_sad.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 11,
                NameBook = "Лолита",
                TheAuthorsid =4,
                Ganresid =4,
                BookDescription = "Сорокалетний литератор и рантье, перебравшись из Парижа в Америку, влюбляется в двенадцатилетнюю провинциальную школьницу, стремление обладать которой становится его губительной манией. Принесшая Владимиру Набокову (1899-1977) мировую известность, технически одна из наиболее совершенных его книг – дерзкая, глубокая, остроумная, пронзительная и живая, – \"Лолита\" (1955) неизменно делит читателей на две категории: восхищенных ценителей яркого искусства и всех прочих.\r\n\r\nВ середине 60‑х годов Набоков создал русскую версию своей любимой книги, внеся в нее различные дополнения и уточнения. Русское издание увидело свет в Нью‑Йорке в 1967 году. Несмотря на запрет, продлившийся до 1989 года, \"Лолита\" получила в СССР широкое распространение и оказала значительное влияние на всю последующую русскую литературу.",
                YearPublishing = new DateTime(2021, 02, 22),
                NumberPages =544,
                Publisherid =2,
                Price =28,
                Bindingid =1,
                Formatid =3,
                BookWeight =500,
                AgeLimit =18,
                Importerid =1,
                TitleNameImage = "nabokov_lolita.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 12,
                NameBook = "Защита Лужина",
                TheAuthorsid =4,
                Ganresid =4,
                BookDescription = "\"Защита Лужина\" (1929) – вершинное достижение Владимира Набокова 20‑х годов, его первая большая творческая удача, принесшая ему славу лучшего молодого писателя русской эмиграции. Показав, по словам Глеба Струве, \"колдовское владение темой и материалом\", Набоков этим романом открыл в русской литературе новую яркую страницу. Гениальный шахматист Александр Лужин, живущий скорее в мире своего отвлеченного и строгого искусства, чем в реальном Берлине, обнаруживает то, что можно назвать комбинаторным началом бытия. Безуспешно пытаясь разгадать \"ходы судьбы\" и прервать их зловещее повторение, он перестает понимать, где кончается игра и начинается сама жизнь, против неумолимых обстоятельств которой он беззащитен.",
                YearPublishing = new DateTime(2021, 02, 22),
                NumberPages =288,
                Publisherid =2,
                Price =24,
                Bindingid =1,
                Formatid =3,
                BookWeight =310,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "nabokov_zashita_lyjina.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 13,
                NameBook = "Ада, или Отрада",
                TheAuthorsid =4,
                Ganresid =4,
                BookDescription = "В конце 60-х годов прошлого века живший в Швейцарии знаменитый русский писатель создал на английском языке грандиозное произведение, преобразившее историю американской литературы. Фантастически смелый по замыслу и воплощению, в полной мере отразивший полувековой писательский и научный опыт Владимира Набокова (1899-1977), роман \"Ада, или Отрада\" (1969) не поддается привычным жанровым определениям. Написанный в форме семейной хроники, охватывающей полтора столетия и длинный ряд персонажей, он представляет собой, возможно, самую необычную историю любви из когда-либо изложенных на каком-либо языке.",
                YearPublishing = new DateTime(2022, 02, 22),
                NumberPages =800,
                Publisherid =3,
                Price =45,
                Bindingid =1,
                Formatid =3,
                BookWeight =760,
                AgeLimit =18,
                Importerid =1,
                TitleNameImage = "nabokov_ada_otrada.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 14,
                NameBook = "Дар",
                TheAuthorsid =4,
                Ganresid =4,
                BookDescription = "\"Дар\" – книга, официально считающаяся \"центральным русскоязычным романом Владимира Набокова\". Во всех возможных отношениях...  Потому что в книге этой интеллектуальная и этическая трагедия русской эмиграции обнажена искренне и жестоко... Потому что непревзойденный \"набоковский язык\" доходит здесь до пределов совершенства – а порой их и превосходит... Потому что \"Дар\" – это шедевр. И комментарии излишни.",
                YearPublishing = new DateTime(2022, 02, 22),
                NumberPages =480,
                Publisherid =1,
                Price =30,
                Bindingid =1,
                Formatid =3,
                BookWeight =490,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "nabokov_dar.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });
            builder.Entity<Books>().HasData(new Books
            {
                Id = 15,
                NameBook = "Бледный огонь",
                TheAuthorsid =4,
                Ganresid =4,
                BookDescription = "\"Бледный огонь\" (1962) – самое необычное по форме произведение Владимира Набокова, состоящее из эпиграфа, одноименной поэмы в 999 строк, предисловия к ней, обширного комментария и указателя. Обстоятельства сочинения Джоном Шейдом гениальной поэмы в последние недели его жизни преломляются в фантастической призме комментария, составленного загадочным и одиноким поклонником американского поэта Чарльзом Кинботом, наполняющим мир \"Бледного огня\" собственным творческим опытом, воспоминаниями и страхами.\r\n\r\nВ настоящем издании роман печатается в переводе Веры Набоковой.",
                YearPublishing = new DateTime(2022, 02, 22),
                NumberPages =368,
                Publisherid =1,
                Price =28,
                Bindingid =1,
                Formatid =3,
                BookWeight =360,
                AgeLimit =16,
                Importerid =1,
                TitleNameImage = "nabokov_bledni_ogon.jpg",
                DateAddSite = new DateTime(2022, 10, 08)
            });


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
