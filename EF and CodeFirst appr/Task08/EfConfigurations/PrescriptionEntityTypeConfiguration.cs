using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models;

namespace Task08.EfConfigurations
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Patient)
            .WithMany(s => s.Prescriptions)
            .HasForeignKey(e => e.IdPatient);

            builder.HasOne(e => e.Doctor)
            .WithMany(s => s.Prescriptions)
            .HasForeignKey(e => e.IdDoctor);
        }
    }
}
