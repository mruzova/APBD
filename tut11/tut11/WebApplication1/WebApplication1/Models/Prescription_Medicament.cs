using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Prescription_Medicament
    {
      
        public int IdMedicament { get; set; }

        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

    }
}
