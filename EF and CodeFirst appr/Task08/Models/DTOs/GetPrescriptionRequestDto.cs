using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task08.Models.DTOs
{
    public class GetPrescriptionRequestDto
    {
        public int idPrescription { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientSecondName { get; set; }
        public int IdDoctor { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorSecondName { get; set; }

        public IEnumerable<string> Medicaments { get; set; }

    }
}
