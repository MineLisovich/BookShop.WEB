using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.WEB.Migrations
{
    public partial class bookshopDB : Migration
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
                    TitleNameImage = table.Column<string>(nullable: false),
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
                    { "333", "a12a1416-c8b0-492f-a925-2bc4245da102", "user", "USER" },
                    { "666", "e8fc6dce-bbb8-4d8a-977c-9766e8f2e7c2", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "393", 0, "f09dedf5-8ebf-42a8-ba9d-8b7f5432f61d", "user@mail.ru", true, false, null, "user@mail.ru", "user", "AQAAAAEAACcQAAAAEISk/h7EQ6kS5uOv8ePxGwF8xvloczi8ekcxVsilp6Hyzof/WINKcIFJC0V9QhKLPg==", null, false, "", false, "user" },
                    { "696", 0, "102500ae-156c-4963-ac8f-898f54799f2d", "bookshop@mail.ru", true, false, null, "bookshop@mail.ru", "admin", "AQAAAAEAACcQAAAAEOE9DfCi7SoGiUw1OSi7GifPc9dZXIvsUimWWojAZM2q/yV49aWtW81kfEaKVfo1Jw==", null, false, "", false, "admin" }
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
                    { "696", "666" },
                    { "393", "333" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeLimit", "Bindingid", "BookDescription", "BookWeight", "DateAddSite", "Formatid", "Ganresid", "Importerid", "NameBook", "NumberPages", "Price", "Publisherid", "TheAuthorsid", "TitleNameImage", "YearPublishing" },
                values: new object[] { 1, 12, 1, "Тут будет описание книги", 456, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "Книга 1", 134, 12, 1, 1, "Book1.jpg", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
