using HamburgerciMVC.DATA.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerciMVC.DATA.Mapping
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("MenuId")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired(); // Id sütunu artık zorunlu (NOT NULL)

            builder.Property(x => x.MenuAdi)
                .HasColumnType("nvarchar(50)") // Veri tipini belirtin ve uzunluğu ayarlayın
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("MenüAdı");

            builder.Property(x => x.MenuFiyat)
                .HasColumnType("float") // double yerine float kullanın
                .IsRequired()
                .HasColumnName("MenuFiyat");

            builder.Property(x => x.ImagePath)
                .HasColumnType("nvarchar(1000)") // Veri tipini belirtin ve uzunluğu ayarlayın
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("ImagePath");
        }
    }
}
