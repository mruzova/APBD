using System;
using System.Collections.Generic;

namespace task10.Models
{
    public partial class Animal
    {
        public Animal()
        {
            ProcedureAnimal = new HashSet<ProcedureAnimal>();
        }

        public int IdAnimal { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int IdOwner { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; }
        public virtual ICollection<ProcedureAnimal> ProcedureAnimal { get; set; }
    }
}
