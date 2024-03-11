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
    internal class EkstraMalzemeMapping : IEntityTypeConfiguration<EkstraMalzeme>
    {
        public void Configure(EntityTypeBuilder<EkstraMalzeme> builder)
        {

            builder.ToTable("EkstraMalzeme"); 
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .HasColumnName("EkstraMalzemeAdi")
                .HasColumnType("nvarchar")
                .HasColumnOrder(1);


            builder.Property(x => x.EkstraMalzemeFiyati)
                .HasColumnName("EkstraMalzemeFiyati")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("decimal");


            builder.Property(x => x.EkstraMalzemeName)
                .HasColumnName("EkstraMalzemeİsim")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar");



        }
    }
}
