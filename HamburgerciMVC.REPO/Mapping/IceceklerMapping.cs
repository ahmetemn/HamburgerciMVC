using HamburgerciMVC.DATA.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.REPO.Mapping
{
	public class IceceklerMapping:IEntityTypeConfiguration<Icecek>
	{
		public void Configure(EntityTypeBuilder<Icecek> builder)
		{

			builder.ToTable("İçecekler");
			builder.HasKey(e => e.Id);

			builder.Property(x => x.Id)
				.HasColumnName("IcecekId")
				.HasColumnType("int")
				.HasColumnOrder(1);


			builder.Property(x => x.Fiyat)
				.HasColumnName("İçecekFiyatı")
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType("decimal");


			builder.Property(x => x.IcecekAdi)
				.HasColumnName("İçecek Adı")
				.IsRequired()
				.HasMaxLength(150)
				.HasColumnType("nvarchar");

            builder.Property(x => x.ImagePath)
                .HasColumnType("nvarchar(1000)") // Veri tipini belirtin ve uzunluğu ayarlayın
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("ImagePath");
        }
	}
}
