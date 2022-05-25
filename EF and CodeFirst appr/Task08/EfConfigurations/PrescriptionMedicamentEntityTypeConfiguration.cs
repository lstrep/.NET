using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models;

namespace Task08.EfConfigurations
{
    public class PrescriptionMedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
            builder.HasOne(e => e.Medicament)
            .WithMany(s => s.Prescription_Medicaments)
            .HasForeignKey(p => p.IdMedicament);

            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
            builder.HasOne(e => e.Prescription)
            .WithMany(s => s.Prescription_Medicaments)
            .HasForeignKey(p => p.IdPrescription);

            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        }
    }
}
