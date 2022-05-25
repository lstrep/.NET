using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task08.EfConfigurations;

namespace Task08.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl; Initial Catalog=s20351; Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEntityTypeConfiguration());



            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.HasData(new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "email@gmail.com" });
                opt.HasData(new Doctor { IdDoctor = 2, FirstName = "Marcin", LastName = "Marcinowicz", Email = "email2@gmail.com" });
                opt.HasData(new Doctor { IdDoctor = 3, FirstName = "Filip", LastName = "Filipowicz", Email = "email3@gmail.com" });
                opt.HasData(new Doctor { IdDoctor = 4, FirstName = "Bartosz", LastName = "Bartkowicz", Email = "email4@gmail.com" });
            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.HasData(new Patient
                {
                    IdPatient = 1,
                    FirstName = "Bartosz",
                    LastName = "Chory",
                    Birthdate = DateTime.Parse("01/10/1990")
                });
                opt.HasData(new Patient
                {
                    IdPatient = 2,
                    FirstName = "Tomasz",
                    LastName = "Bardzochory",
                    Birthdate = DateTime.Parse("01/10/1990")
                });

            });

            modelBuilder.Entity<Prescription>(opt =>
            {
                opt.HasData(new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Today,
                    DueDate = DateTime.Parse("10/10/2022"),
                    IdPatient = 1,
                    IdDoctor = 1
                });

                opt.HasData(new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Today,
                    DueDate = DateTime.Parse("10/10/2022"),
                    IdPatient = 2,
                    IdDoctor = 2
                });
            });

            modelBuilder.Entity<Medicament>(opt =>
            {
                opt.HasData(new Medicament
                {
                    IdMedicamenet = 1,
                    Name = "Lek",
                    Description = "opis",
                    Type = "Typ"

                });

                opt.HasData(new Medicament
                {
                    IdMedicamenet = 2,
                    Name = "Słaby Lek",
                    Description = "Słaby opis",
                    Type = "Typ"

                });

            });

            modelBuilder.Entity<Prescription_Medicament>(opt =>
            {
                opt.HasData(new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Details = "Szczegóły"

                });


                opt.HasData(new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 2,
                    Details = "Szczegóły"

                });

            });

        }




    }
}
