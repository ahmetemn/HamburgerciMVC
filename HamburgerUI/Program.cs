using HamburgerciMVC.REPO.Abstract;
using HamburgerciMVC.REPO.ConcrateREPO;
using HamburgerciMVC.REPO.Context;
using HamburgerMVC.SERVICE.Service.MenuService;
using System;

namespace HamburgerUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddScoped<IMenuHamburgerREPO,MenuHamburgerREPO>();

            builder.Services.AddScoped<IMenuService, MenuService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute(

                name: "AdminPanel",
                areaName: "AdminPanel",
                pattern: "AdminArea/{controller=Admin}/{action=Listele}/{id?}"


                ); 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}