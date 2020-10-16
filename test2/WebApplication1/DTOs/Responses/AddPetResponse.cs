using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class AddPetResponse
    {
 
        public string BreedName { get; set; }
 
        public string Name { get; set; }
 
        public bool IsMale { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime ApproximatedDateOfBirth { get; set; }
    }
}
