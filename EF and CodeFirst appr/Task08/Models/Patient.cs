using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task08.Models
{
    public class Patient
    {

        public int IdPatient { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();

    }
}
