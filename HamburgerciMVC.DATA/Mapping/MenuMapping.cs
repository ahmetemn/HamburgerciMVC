using HamburgerciMVC.DATA.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Mapping
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {

            builder.ToTable("Menu"); 
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Kategori_Id")
                .HasColumnType("integer")
                .HasColumnOrder(1);

            builder.Property(x => x.MenuAdi)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("MenüAdı");

            builder.Property(x => x.MenuFiyat)
                .HasColumnType("double")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("MenuFiyat");


            builder.Property(x => x.ImagePath)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("ImagePath");
        }
    }
}
