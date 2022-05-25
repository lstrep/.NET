using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using s20351Retake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.EFConfigurations
{
    public class ClientOrderEntityTypeConfiguration : IEntityTypeConfiguration<ClientOrder>
    {
        public void Configure(EntityTypeBuilder<ClientOrder> builder)
        {
            builder.HasKey(e => e.IdClientOrder);
            //builder.Property(e => e.IdClientOrder).ValueGeneratedOnAdd();

            builder.Property(e => e.OrderDate).IsRequired();


            builder.HasOne(e => e.Client)
               .WithMany(s => s.ClientOrders)
               .HasForeignKey(e => e.IdClient);

            builder.HasOne(e => e.Employee)
               .WithMany(s => s.ClientOrders)
               .HasForeignKey(e => e.IdEmployee);

            builder.HasData(
              new ClientOrder
              {
                  IdClientOrder = 1,
                  OrderDate = DateTime.Now,
                  CompletionDate = DateTime.Now.AddDays(3),
                  Comments = "Some comments",
                  IdClient = 1,
                  IdEmployee = 1

              },
              new ClientOrder
              {
                  IdClientOrder = 2,
                  OrderDate = DateTime.Now,
                  CompletionDate = DateTime.Now.AddDays(5),
                  Comments = "Some comments",
                  IdClient = 2,
                  IdEmployee = 2
              });


        }
    }
}
