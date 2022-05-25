using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using s20351Retake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.EFConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.IdClient);
            builder.Property(e => e.IdClient).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(60);

            builder.HasData(
               new Client
               {
                   IdClient = 1,
                   FirstName = "Bartek",
                   LastName = "Bartkowski"

               },
               new Client
               {
                   IdClient = 2,
                   FirstName = "Tomek",
                   LastName = "Nowak"
               });
        }
    }
}
