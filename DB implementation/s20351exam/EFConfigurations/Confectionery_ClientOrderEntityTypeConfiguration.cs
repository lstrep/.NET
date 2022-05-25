using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using s20351Retake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.EFConfigurations
{
    public class Confectionery_ClientOrderEntityTypeConfiguration : IEntityTypeConfiguration<Confectionery_ClientOrder>
    {
        public void Configure(EntityTypeBuilder<Confectionery_ClientOrder> builder)
        {

            builder.HasKey(e => new { e.IdClientOrder, e.IdConfectionery });
            builder.HasOne(e => e.ClientOrder)
           .WithMany(s => s.Confectionery_ClientOrders)
           .HasForeignKey(e => e.IdClientOrder);

            //builder.HasKey(e => e.IdConfectionery);
            builder.HasOne(e => e.Confectionery)
           .WithMany(s => s.Confectionery_ClientOrders)
           .HasForeignKey(e => e.IdConfectionery);

            builder.Property(s => s.Amount).IsRequired();
            builder.Property(s => s.Comments).HasMaxLength(300);


            builder.HasData(
               new Confectionery_ClientOrder
               {

                   IdClientOrder = 1,
                   IdConfectionery = 1,
                   Amount = 30,
                   Comments = "comments"

               },
               new Confectionery_ClientOrder
               {

                   IdClientOrder = 2,
                   IdConfectionery = 2,
                   Amount = 500,
                   Comments = "comments"
               });

        }
    }
}
