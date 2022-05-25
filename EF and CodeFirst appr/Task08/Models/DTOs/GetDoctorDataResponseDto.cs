using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task08.Models.DTOs
{
    public class GetDoctorDataResponseDto
    {

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
