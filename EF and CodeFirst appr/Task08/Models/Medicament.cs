using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task08.Models
{
    public class Medicament
    {

        public int IdMedicamenet { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public string Type { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
            = new HashSet<Prescription_Medicament>();

    }
}
