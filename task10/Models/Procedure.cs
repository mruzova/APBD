using System;
using System.Collections.Generic;

namespace task10.Models
{
    public partial class Procedure
    {
        public Procedure()
        {
            ProcedureAnimal = new HashSet<ProcedureAnimal>();
        }

        public int IdProcedure { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProcedureAnimal> ProcedureAnimal { get; set; }
    }
}
