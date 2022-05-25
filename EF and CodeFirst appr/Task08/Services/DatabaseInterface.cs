using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models.DTOs;

namespace Task08.Models.Services
{
    public interface DatabaseInterface
    {

        public List<GetDoctorDataResponseDto> GetDoctorData(int idDoctor);
        public Task AddDoctor(AddDoctorToDatabaseRequestDto doctor);
        public Task ModifyDoctor(int idDoctor, AddDoctorToDatabaseRequestDto doctor);
        public Task DeleteDoctor(int idDoctor);
        public Task<GetPrescriptionRequestDto> GetPrescription(int idPatient);


    }
}
