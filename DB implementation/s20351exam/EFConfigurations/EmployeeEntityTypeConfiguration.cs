using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using s20351Retake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.EFConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.IdEmployee);
            builder.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(60);

            builder.HasData(
               new Employee
               {
                   IdEmployee = 1,
                   FirstName = "Michał",
                   LastName = "Michaulowski"

               },
               new Employee
               {
                   IdEmployee = 2,
                   FirstName = "Krzys",
                   LastName = "Krzysiowski"
               });
        }
    }
}
