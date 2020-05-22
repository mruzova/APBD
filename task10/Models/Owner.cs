using System;
using System.Collections.Generic;

namespace task10.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Animal = new HashSet<Animal>();
        }

        public int IdOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
