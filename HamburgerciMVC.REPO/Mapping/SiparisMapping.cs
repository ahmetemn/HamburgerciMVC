using HamburgerciMVC.DATA.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Mapping
{
    public class SiparisMapping : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Siparis> builder)
        {


            builder.ToTable("Siparis");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Siparis_Id")
                .HasColumnType("int")
                .HasColumnOrder(1);


         

            builder.HasMany(x => x.EkstraMalzemes)
               .WithOne(m => m.Siparis)
               .HasForeignKey(m => m.SiparisId)
               .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
