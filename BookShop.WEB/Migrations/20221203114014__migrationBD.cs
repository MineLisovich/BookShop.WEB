using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.WEB.Migrations
{
    public partial class _migrationBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Binding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBinding = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFormat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ganres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGanre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Importer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameImporter = table.Column<string>(nullable: false),
                    AddressImpoter = table.Column<string>(nullable: false),
                    postcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurStores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressStore = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortNamePublisher = table.Column<string>(nullable: false),
                    FullNamePublisher = table.Column<string>(nullable: false),
                    AddressPublisher = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    NameBook = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AdressDelivery = table.Column<string>(nullable: false),
                    PhoneUser = table.Column<string>(nullable: false),
                    DataDlivery = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pickup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    NameBook = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    OurStoresid = table.Column<int>(nullable: false),
                    DateIssueOrder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pickup_OurStores_OurStoresid",
                        column: x => x.OurStoresid,
                        principalTable: "OurStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pickup_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBook = table.Column<string>(nullable: false),
                    TheAuthorsid = table.Column<int>(nullable: false),
                    Ganresid = table.Column<int>(nullable: false),
                    BookDescription = table.Column<string>(nullable: false),
                    YearPublishing = table.Column<DateTime>(nullable: false),
                    NumberPages = table.Column<int>(nullable: false),
                    Publisherid = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Bindingid = table.Column<int>(nullable: false),
                    Formatid = table.Column<int>(nullable: false),
                    BookWeight = table.Column<int>(nullable: false),
                    AgeLimit = table.Column<int>(nullable: false),
                    Importerid = table.Column<int>(nullable: false),
                    TitleNameImage = table.Column<string>(nullable: true),
                    DateAddSite = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Binding_Bindingid",
                        column: x => x.Bindingid,
                        principalTable: "Binding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Format_Formatid",
                        column: x => x.Formatid,
                        principalTable: "Format",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Ganres_Ganresid",
                        column: x => x.Ganresid,
                        principalTable: "Ganres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Importer_Importerid",
                        column: x => x.Importerid,
                        principalTable: "Importer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_Publisherid",
                        column: x => x.Publisherid,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_TheAuthors_TheAuthorsid",
                        column: x => x.TheAuthorsid,
                        principalTable: "TheAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Booksid = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Books_Booksid",
                        column: x => x.Booksid,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "333", "9eea2856-2ee2-4367-9c38-493d4fd25590", "user", "USER" },
                    { "666", "0c4968a4-50f3-4a7e-8129-1077b53172f6", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "393", 0, "eb1240ed-25f1-4e28-a55a-131e11b19ab6", "user@mail.ru", true, false, null, "user@mail.ru", "user", "AQAAAAEAACcQAAAAEDOmSoSS+xvI7C+xSbpgUPKhRVQgiRiLsogPsMypHthMtUktS0RsoWbXZZI+KZvntg==", null, false, "", false, "user" },
                    { "696", 0, "46d718db-800e-4f5d-a948-a77f94361c5f", "bookshop@mail.ru", true, false, null, "bookshop@mail.ru", "admin", "AQAAAAEAACcQAAAAEDtYV/ksSURwBd/QbXzh7XarfyZc1zA0MU/wYMGi3DfgnWI6zDkL9BMULggPW1X5HA==", null, false, "", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Binding",
                columns: new[] { "Id", "NameBinding" },
                values: new object[,]
                {
                    { 1, "Твёрдый переплёт" },
                    { 2, "Мягкий переплёт" }
                });

            migrationBuilder.InsertData(
                table: "Format",
                columns: new[] { "Id", "NameFormat" },
                values: new object[,]
                {
                    { 4, "Малый — (70×90/32; 70×108/32)" },
                    { 2, "Крупный — (70×90/16; 75×90/16)" },
                    { 3, "Средний — (60×90/16; 84×108/32)" },
                    { 1, "Сверхкрупный — (84×108/8; 70×90/8)" },
                    { 5, "Сверхмалый — (60×90/32)" }
                });

            migrationBuilder.InsertData(
                table: "Ganres",
                columns: new[] { "Id", "NameGanre" },
                values: new object[,]
                {
                    { 4, "Роман" },
                    { 5, "Научная книга" },
                    { 6, "Фольклор" },
                    { 2, "Фантастика" },
                    { 8, "Поэзия, проза" },
                    { 9, "Детская книга" },
                    { 10, "Документальная литература" },
                    { 1, "Детектив" },
                    { 3, "Приключения" },
                    { 7, "Юмор" }
                });

            migrationBuilder.InsertData(
                table: "Importer",
                columns: new[] { "Id", "AddressImpoter", "FullNameImporter", "postcode" },
                values: new object[,]
                {
                    { 1, "РБ, г.Минск, ул. Скрыганова 14, каб. 36 ", "ООО <<Приносим радость>>", 220073 },
                    { 2, "РБ, г.Минск ул. Кульман 1/3-42", "ООО <<Харвест>>", 220013 }
                });

            migrationBuilder.InsertData(
                table: "OurStores",
                columns: new[] { "Id", "AdressStore" },
                values: new object[] { 1, "Г.Минск, Ул. Ландыши 1" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "AddressPublisher", "FullNamePublisher", "ShortNamePublisher" },
                values: new object[,]
                {
                    { 5, "РФ, г.Москва, ул. Зубовский бульвар 13 стр.2", "ООО <<Издательсво Синдбад>>", "Синдбад" },
                    { 3, "РФ, г.Москва, Волгоградский Просп, д. 3-5", "ООО <<Комильфо>>", "Комильфо" },
                    { 1, "РФ, г.Москва, ул. Клары Цеткин 18,корп.5", "ООО <<Издательство Эксмо>>", "Эксмо" },
                    { 4, "РФ, г.Москва, б-р Звёздный 21, стр.1", "Творческое кооперативное объединение <<АСТ>>", "АСТ" },
                    { 2, "РБ, г.Минск, ул. Олешева 1, офис 309", "ОДО <<Аверсэв>>", "Аверсэв" }
                });

            migrationBuilder.InsertData(
                table: "TheAuthors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Лев Николаевич Толстой" },
                    { 2, "Уильям Шекспир" },
                    { 3, "Джеймс Джойс" },
                    { 4, "Владимир Владимирович Набоков" },
                    { 5, "Фёдор Михайлович Достоевский" },
                    { 6, "Уильям Фолкнер" },
                    { 7, "Чарльз Диккенс" },
                    { 8, "Антон Павлович Чехов" },
                    { 9, "Гюстав Флобер" },
                    { 10, "Джейн Остин" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "393", "333" },
                    { "696", "666" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeLimit", "Bindingid", "BookDescription", "BookWeight", "DateAddSite", "Formatid", "Ganresid", "Importerid", "NameBook", "NumberPages", "Price", "Publisherid", "TheAuthorsid", "TitleNameImage", "YearPublishing" },
                values: new object[,]
                {
                    { 10, 12, 1, "Драматургия искусство особое. Как известно, современники Чехова в восприятии его пьес разделились на два лагеря. Горячие поклонники Художественного театра наталкивались на вежливое равнодушие или откровенную неприязнь даже тех, кто был весьма расположен к Чехову-прозаику. \"Чехов несомненный талант, но пьесы его плохие. В них не решаются вопросы, нет содержания\", не раз повторял в беседах Л. Толстой. \"Пьесы его далеко не лучшее из написанного им...\" говорил И. Бунин. В XX веке многое изменилось. С развитием режиссерского театра драма как текст утратила свое значение она живет и умирает в спектакле. И только немногие пьесы наверное, они и называются классикой необходимо не только видеть на сцене, но и читать.", 275, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, 2, "Вишневый сад", 320, 15, 2, 8, "chehov_vishevi_sad.jpg", new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 16, 2, "Где та грань, которая отделяет здорового человека от больного, особенно если речь идет о нервных заболеваниях, ведь избежать нервные потрясения или перегрузки практически невозможно? Антон Чехов будучи сам врачом во многих своих произведениях рассказывает истории людей, незаметно переходящих эту грань, людей, которых убивает рутина, серые будни, и будучи чрезвычайно чувствительными и слабыми они ломаются под давлением обыденности и неспособности что-то противопоставить ей.", 170, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 1, "Палата №6", 352, 9, 1, 8, "chehov_palata6.jpg", new DateTime(2012, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, 1, "В книгу вошли известнейшие и всеми любимые рассказы великого русского писателя Антона Павловича Чехова: \"Каштанка\", \"Пересолил\", \"Лошадиная фамилия\", \"Толстый и тонкий\" и другие. Чехов умел сочетать весёлое и грустное, и удивительно проникновенно говорить о самых обыкновенных вещах. Каждый его рассказ – целый мир, который умещается всего на нескольких страницах.", 200, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 1, "Каштанка", 128, 9, 1, 8, "chehov_kashtanka.jpg", new DateTime(2016, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 16, 1, "Последний, самый объемный и один из наиболее известных романов Ф. М. Достоевского обращает читателя к вневременным нравственно-философским вопросам о грехе, воздаянии, сострадании и милосердии. Книга, которую сам писатель определил как \"роман о богохульстве и опровержении его\", явилась попыткой \"решить вопрос о человеке\", \"разгадать тайну\" человека, что, по Достоевскому, означало \"решить вопрос о Боге\". Сквозь призму истории провинциальной семьи Карамазовых автор повествует об извечной борьбе Божественного и дьявольского в человеческой душе. Один из самых глубоких в мировой литературе опытов отражения христианского сознания, \"Братья Карамазовы\" стали в ХХ веке объектом парадоксальных философских и психоаналитических интерпретаций.", 560, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Братья Карамазовы", 832, 15, 1, 5, "dostoevski_bratya_karamazobi.jpg", new DateTime(2013, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 16, 1, @"""Главная идея... – писал Ф. М. Достоевский о своем романе ""Идиот"", – изобразить положительно-прекрасного человека. Труднее этого нет ничего на свете..."" Не для того ли писатель явил миру ""князя-Христа"", чтобы мы не забывали: ""Страдание есть главнейший и, может быть, единственный закон бытия всего человечества"".

                Каждое новое поколение по-своему воспринимает классику и пытается дать собственные ответы на вечные вопросы бытия. Об этом свидетельствуют и известные экранизации романа, его сценические версии. В России запоминающиеся образы князя Мышкина создали Ю. Яковлев, И. Смоктуновский, Е. Миронов.", 450, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Идиот", 640, 15, 1, 5, "dostoevski_idiot.jpg", new DateTime(2012, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 16, 1, @"""Бледный огонь"" (1962) – самое необычное по форме произведение Владимира Набокова, состоящее из эпиграфа, одноименной поэмы в 999 строк, предисловия к ней, обширного комментария и указателя. Обстоятельства сочинения Джоном Шейдом гениальной поэмы в последние недели его жизни преломляются в фантастической призме комментария, составленного загадочным и одиноким поклонником американского поэта Чарльзом Кинботом, наполняющим мир ""Бледного огня"" собственным творческим опытом, воспоминаниями и страхами.

                В настоящем издании роман печатается в переводе Веры Набоковой.", 360, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Бледный огонь", 368, 28, 1, 4, "nabokov_bledni_ogon.jpg", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 16, 1, "Одно из \"краеугольных\" произведений русской и мировой литературы, включенный во все школьные и университетские программы, неоднократно экранизированный роман Достоевского \"Преступление и наказание\" ставит перед читателем важнейшие нравственно-мировоззренческие вопросы – о вере, совести, грехе и об искуплении через страдание. Опровержение преступной \"идеи-страсти\", \"безобразной мечты\", завладевшей умом Родиона Раскольникова в самом \"умышленном\" и \"фантастическом\" городе на свете, составляет основное содержание этой сложнейшей, соединившей в себе несколько различных жанров книги. Задуманный как \"психологический отчет одного преступления\", роман Достоевского предстал перед читателем грандиозным художественно-философским исследованием человеческой природы, христианской трагедией о смерти и воскресении души.", 430, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Преступление и наказание", 608, 14, 4, 5, "dostoevski_prestyplenie_nakazanie.jpg", new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 18, 1, "В конце 60-х годов прошлого века живший в Швейцарии знаменитый русский писатель создал на английском языке грандиозное произведение, преобразившее историю американской литературы. Фантастически смелый по замыслу и воплощению, в полной мере отразивший полувековой писательский и научный опыт Владимира Набокова (1899-1977), роман \"Ада, или Отрада\" (1969) не поддается привычным жанровым определениям. Написанный в форме семейной хроники, охватывающей полтора столетия и длинный ряд персонажей, он представляет собой, возможно, самую необычную историю любви из когда-либо изложенных на каком-либо языке.", 760, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Ада, или Отрада", 800, 45, 3, 4, "nabokov_ada_otrada.jpg", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 16, 1, "\"Защита Лужина\" (1929) – вершинное достижение Владимира Набокова 20‑х годов, его первая большая творческая удача, принесшая ему славу лучшего молодого писателя русской эмиграции. Показав, по словам Глеба Струве, \"колдовское владение темой и материалом\", Набоков этим романом открыл в русской литературе новую яркую страницу. Гениальный шахматист Александр Лужин, живущий скорее в мире своего отвлеченного и строгого искусства, чем в реальном Берлине, обнаруживает то, что можно назвать комбинаторным началом бытия. Безуспешно пытаясь разгадать \"ходы судьбы\" и прервать их зловещее повторение, он перестает понимать, где кончается игра и начинается сама жизнь, против неумолимых обстоятельств которой он беззащитен.", 310, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Защита Лужина", 288, 24, 2, 4, "nabokov_zashita_lyjina.jpg", new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 18, 1, @"Сорокалетний литератор и рантье, перебравшись из Парижа в Америку, влюбляется в двенадцатилетнюю провинциальную школьницу, стремление обладать которой становится его губительной манией. Принесшая Владимиру Набокову (1899-1977) мировую известность, технически одна из наиболее совершенных его книг – дерзкая, глубокая, остроумная, пронзительная и живая, – ""Лолита"" (1955) неизменно делит читателей на две категории: восхищенных ценителей яркого искусства и всех прочих.

                В середине 60‑х годов Набоков создал русскую версию своей любимой книги, внеся в нее различные дополнения и уточнения. Русское издание увидело свет в Нью‑Йорке в 1967 году. Несмотря на запрет, продлившийся до 1989 года, ""Лолита"" получила в СССР широкое распространение и оказала значительное влияние на всю последующую русскую литературу.", 500, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Лолита", 544, 28, 2, 4, "nabokov_lolita.jpg", new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 16, 1, "В книгу вошли произведения У. Шекспира, которые изучаются в школе. \"Ромео и Джульетта\" – трагедия, рассказывающая о любви юноши и девушки из двух враждующих старинных родов – Монтекки и Капулетти, и одна из самых знаменитых пьес в мировой литературе \"Гамлет\".", 340, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, 1, "Ромео и Джульетта. Гамлет", 352, 15, 1, 2, "shekspir_romeo_djyletta_gamlet.jpg", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 12, 1, "Повесть \"Детство\", впервые опубликованная в 1852 году в журнале \"Современник\", стала литературным дебютом Л. Н. Толстого, выдающегося русского писателя и мыслителя. Опираясь на детские воспоминания и дневниковые записи, Толстой, однако, писал не автобиографию и не мемуары. Автор пытался раскрыть универсальные законы развития человеческой души, ее загадочную изменчивую \"диалектику\", \"высказать такие тайны, которые нельзя сказать простым словом\", что как раз и составляет главную цель искусства, как считал автор. Впоследствии повесть \"Детство\" вместе с \"Отрочеством\" (1852-1854) и \"Юностью\" (1855-1857) соединились в трилогию и стали \"не только копилкой будущих литературных замыслов, но и некой абсолютной точкой на пути, раз и навсегда открытым континентом на карте толстовского мира\" (И. Н. Сухих).", 322, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, 1, "Детство. Отрочество. Юность", 416, 24, 3, 1, "lev_tolstoj_otchestvo.jpg", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 16, 1, "\"Анна Каренина\" – лучший роман о женщине, написанный в XIX веке. По словам Ф. М. Достоевского, \"Анна Каренина\" поразила современников \"не только вседневностью содержания, но и огромной психологической разработкой души человеческой, страшной глубиной и силой\". Уже к началу 1900-х годов роман Толстого был переведен на многие языки мира, а в настоящее время входит в золотой фонд мировой литературы.", 571, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Анна Каренина", 864, 15, 2, 1, "Lev_Tolstoy_Anna__Karen__ina.jpg", new DateTime(2012, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 16, 1, "\"Дар\" – книга, официально считающаяся \"центральным русскоязычным романом Владимира Набокова\". Во всех возможных отношениях...  Потому что в книге этой интеллектуальная и этическая трагедия русской эмиграции обнажена искренне и жестоко... Потому что непревзойденный \"набоковский язык\" доходит здесь до пределов совершенства – а порой их и превосходит... Потому что \"Дар\" – это шедевр. И комментарии излишни.", 490, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Дар", 480, 30, 1, 4, "nabokov_dar.jpg", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 12, 1, "Жизнь, творческий путь, идейные искания Л.Н.Толстого по-прежнему увлекают умы наших современников, которые пытаются понять саму сущность творчества писателя и его учения.\"Война и мир\" - вершина творчества Л.Н.Толстого, как никакое другое произведение писателя отражает глубину его мироощущения и философии. Эта книга из разряда вечных, потому что она обо всем - о жизни и смерти, о любви и чести, о мужестве и героизме, о славе и подвиге, о войне и мире. Самый известный во всем мире роман гениального писателя вот уже третье столетие заставляет читателей сопереживать героям произведения. Роман о русской душе, о русском укладе жизни, о вечных вопросах, которые приходится решать каждому человеку наедине с собой. Все жизненные перипетии героев, происходящие на фоне исторических событий, произошедших в начале ХIХ века с Россией, на фоне кровавых событий войны 1812 года, обретают емкий философский смысл. Роман по глубине и охвату событий до сих пор стоит на первом месте во всей мировой...", 1020, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, "Война и мир (в 2 томах)", 1406, 25, 1, 1, "lev_tolstoj_vojna_i_mir.jpg", new DateTime(2014, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "Id", "AdressDelivery", "DataDlivery", "NameBook", "PhoneUser", "Price", "UserId" },
                values: new object[] { 1, "г.Минск, ул.Лиловая 43, кв 32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book1", "+375(29)454-45-55", 12, "393" });

            migrationBuilder.InsertData(
                table: "Pickup",
                columns: new[] { "Id", "DateIssueOrder", "NameBook", "OurStoresid", "Price", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book1", 1, 12, "393" });

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "Id", "Booksid", "TotalPrice", "UserId" },
                values: new object[] { 1, 1, 12, "393" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Bindingid",
                table: "Books",
                column: "Bindingid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Formatid",
                table: "Books",
                column: "Formatid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Ganresid",
                table: "Books",
                column: "Ganresid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Importerid",
                table: "Books",
                column: "Importerid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisherid",
                table: "Books",
                column: "Publisherid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TheAuthorsid",
                table: "Books",
                column: "TheAuthorsid");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_UserId",
                table: "Delivery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pickup_OurStoresid",
                table: "Pickup",
                column: "OurStoresid");

            migrationBuilder.CreateIndex(
                name: "IX_Pickup_UserId",
                table: "Pickup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Booksid",
                table: "ShoppingCart",
                column: "Booksid");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Pickup");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OurStores");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Binding");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "Ganres");

            migrationBuilder.DropTable(
                name: "Importer");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "TheAuthors");
        }
    }
}
