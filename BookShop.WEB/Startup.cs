using BookShop.WEB.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using BookShop.WEB.DataBase.Repositories.EF;
using BookShop.WEB.DataBase;


namespace BookShop.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� ������ �� appsettings.json
            Configuration.Bind("Project", new Config());

            // ���������� ������ ����������
            services.AddTransient<IBindingRepository, EFBindingRepository>();
            services.AddTransient<IBooksRepository, EFBooksRepository>();
            services.AddTransient<IDeliveryRepository, EFDeliveryRepository>();
            services.AddTransient<IFormatRepository, EFFormatRepository>();
            services.AddTransient<IGanresRepository, EFGanresRepository>();
            services.AddTransient<IImporterRepository, EFImporterRepository>();
            services.AddTransient<IOurStoresRepository,EFOurStoresRepository>();
            services.AddTransient<IPickupRepository,EFPickupRepository>();
            services.AddTransient<IPublisherRepository,EFPublisherRepository>();
            services.AddTransient<IShoppingCartRepository,EFShoppingCartRepository>();
            services.AddTransient<ITheAuthorsRepository, EFTheAuthorsRepository>();
            services.AddTransient<DataManager>();
            services.AddTransient<EmailService>();

            //����������� ��
            services.AddDbContext<Context>(x => x.UseSqlServer(Config.ConnectionString));

            // ��������� ������� identity
            services.AddIdentity<IdentityUser, IdentityRole>(options=>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8; // ����������� ����� ������
                options.Password.RequireNonAlphanumeric = false; //��������� �� ��������-�������� ������ � ������.
                options.Password.RequireDigit = true; //��������� ����� �� 0 �� 9 � ������.
                options.Password.RequireLowercase = true; // ��������� �������� ����� � ������.
                options.Password.RequireUppercase = true;// ��������� ��������� ����� � ������.

            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            // ��������� ������� cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "BookShopCookie";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.SlidingExpiration = true;
            });

            //��������� ������� �����
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy=>
                {
                    policy.RequireRole("admin");
                });
                x.AddPolicy("UserArea", policy =>
                {
                    policy.RequireRole("user");
                });
            });
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin","AdminArea"));
                x.Conventions.Add(new UserAreaAuthorization("User","UserArea"));
            })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("User", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute( "default", "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute("Products", "{controller=Home}/{action=Products}");
                endpoints.MapControllerRoute("Contacts", "{controller=Home}/{action=Contacts}");
                

            });
        }
    }
}
