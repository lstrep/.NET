using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models;
using Task08.Models.DTOs;
using Task08.Models.Services;

namespace WebApplication4.Services
{


    public class DatabaseService : DatabaseInterface
    {
        private readonly MainDbContext _context;

        public DatabaseService(MainDbContext context)
        {
            _context = context;
        }

        public async Task AddDoctor(AddDoctorToDatabaseRequestDto doctor)
        {
            var newDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            await _context.Doctors.AddAsync(newDoctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int idDoctor)
        {
            var doctor = await _context.Doctors.FirstAsync(doctor => doctor.IdDoctor == idDoctor);

            if (doctor.Prescriptions.Select(d => d.IdDoctor == idDoctor) == null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DbUpdateException("Unable to delete doctor");

            }
        }

        public List<GetDoctorDataResponseDto> GetDoctorData(int idDoctor)
        {
            var doctor = _context.Doctors.Where(doctor => doctor.IdDoctor == idDoctor)
                .Select(doctor => new GetDoctorDataResponseDto
                {
                    IdDoctor = doctor.IdDoctor,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                }).ToList();

            return doctor;

        }

        public async Task<GetPrescriptionRequestDto> GetPrescription(int idPrescription)
        {
            var getPrescrition = await _context.Prescriptions.FirstOrDefaultAsync(p => p.IdPrescription == idPrescription);
            var getDoctor = await _context.Doctors.FirstOrDefaultAsync(p => p.IdDoctor == getPrescrition.IdDoctor);
            var getPatient = await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == getPrescrition.IdPatient);
            var getPrescriptionMedicament = await _context.Prescription_Medicaments
                .FirstOrDefaultAsync(p => p.IdPrescription == getPrescrition.IdPrescription);




            var prescription = new GetPrescriptionRequestDto
            {
                idPrescription = idPrescription,
                PatientFirstName = getPatient.FirstName,
                PatientSecondName = getPatient.LastName,
                IdDoctor = getPrescrition.IdDoctor,
                DoctorFirstName = getDoctor.FirstName,
                DoctorSecondName = getDoctor.LastName,
                Medicaments = _context.Medicaments.Where(p => p.IdMedicamenet == getPrescriptionMedicament.IdMedicament).Select(m => m.Name)
            };

            return prescription;
        }

        public async Task ModifyDoctor(int idDoctor, AddDoctorToDatabaseRequestDto doctor)
        {

            var updatedDoctor = _context.Doctors.FirstOrDefault(e => e.IdDoctor == idDoctor);

            _context.Doctors.Remove(updatedDoctor);

            var newDoctor = new Doctor
            {
                IdDoctor = updatedDoctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            await _context.Doctors.AddAsync(newDoctor);
            await _context.SaveChangesAsync();

        }
    }


}
