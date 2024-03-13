using HamburgerciMVC.DATA.Concrate;
using HamburgerciMVC.REPO.Abstract;
using HamburgerciMVC.REPO.ConcrateREPO;
using HamburgerciMVC.REPO.Context;
using HamburgerMVC.SERVICE.Service.MenuService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics.Metrics;

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
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Password
                options.Password.RequireDigit = false; //en az bir rakam.
                options.Password.RequireLowercase = false; //en az bir küçük harf.
                options.Password.RequireUppercase = false; //en az bir büyük harf.
                options.Password.RequiredLength = 3; //Minimum karakter uzunluðu.
                options.Password.RequireNonAlphanumeric = false; //en az bir sembol.

                options.User.RequireUniqueEmail = true; //E-Posta adresi benzersiz olsun.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_"; //Username'in içereceði karakterler.

                options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon onayý
                options.SignIn.RequireConfirmedEmail = false; //E-Posta onayý
            })
              .AddEntityFrameworkStores<ApplicationContext>()
              .AddDefaultTokenProviders();


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

            app.UseAuthentication();
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