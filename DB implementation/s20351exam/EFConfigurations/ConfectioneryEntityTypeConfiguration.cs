using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using s20351Retake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace s20351Retake.EFConfigurations
{
    public class ConfectioneryEntityTypeConfiguration : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.HasKey(e => e.IdConfectionery);
            //builder.Property(e => e.IdConfectionery).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PricePerOne).IsRequired();

            builder.HasData(
               new Confectionery
               {
                   IdConfectionery = 1,
                   Name = "Confectionery 1",
                   PricePerOne = 50

               },
               new Confectionery
               {
                   IdConfectionery = 2,
                   Name = "Confectionery 2",
                   PricePerOne = 100
               });
        }
    }
}
