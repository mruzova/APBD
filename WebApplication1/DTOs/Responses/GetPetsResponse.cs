using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class GetPetsResponse
    {
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApproximateDateOfBirth { get; set; }
        public DateTime DateAdopted { get; set; }
        public List<Pet> pets { get; set; }
        public List<VolunteerResponse> volunteers { get; set; }
    }
}
