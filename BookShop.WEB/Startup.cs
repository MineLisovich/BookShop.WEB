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
            // подключаем конфиг из appsettings.json
            Configuration.Bind("Project", new Config());

            // Подключаем нужный функционал
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

            //Подключение БД
            services.AddDbContext<Context>(x => x.UseSqlServer(Config.ConnectionString));

            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "products", pattern: "{controller=Home}/{action=Products}/{id?}");
                   
            });
        }
    }
}
