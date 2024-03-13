using HamburgerciMVC.DATA.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.REPO.Context
{
    public  class ApplicationContext:IdentityDbContext<AppUser,AppRole ,string>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-12QQ6NC6\AHMET;Database=KD-19-HAMBURGERCİMVC;Trusted_Connection=True;MultipleActiveResultSets=false;TrustServerCertificate=True;");

        }

        public DbSet<EkstraMalzeme> EkstraMalzemes { get; set; }    

        public DbSet<Menu> Menu {  get; set; }  

        public DbSet<Siparis> Siparis { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityUserLogin<string>>().HasKey(p => p.UserId);

        }
    }


}
