using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task08.Models
{
    public class Prescription
    {

        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public int IdPatient { get; set; }

        public Patient Patient { get; set; }

        public int IdDoctor { get; set; }

        public Doctor Doctor { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
        = new HashSet<Prescription_Medicament>();
    }
}
