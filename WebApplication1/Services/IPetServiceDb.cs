using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services
{
    public interface IPetServiceDb
    {
        public GetPetsResponse GetPets(string year = null);
        public AddPetResponse AddPet(AddPetRequest request);
    }
}
