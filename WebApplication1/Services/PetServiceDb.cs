using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PetServiceDb : IPetServiceDb
    {
        public PetAdoptionContext _context { get; set; }
        public PetServiceDb(PetAdoptionContext context)
        {
            _context = context;
        }

        public GetPetsResponse GetPets(string year = null)
        {
            var response = new GetPetsResponse();
            if (year == null)
            {
             
            }
            var pet_year = _context.Pet.FirstOrDefault(p => p.DateRegistered.Year == int.Parse(year));
            if (pet_year == null)
            {
                throw new Exception("there is no such registered year");
            }
            var pet = _context.Pet.Where(p => p.IdPet == pet_year.IdPet).FirstOrDefault();

            var v_p = _context.Volunteer_Pet.FirstOrDefault(p=>p.IdPet==pet.IdPet);
           
            var volunteer = _context.Volunteer.Where(x => x.IdVolunteer == v_p.IdVolunteer);
           
            return response;
        }

        public AddPetResponse AddPet(AddPetRequest request)
        {
            var response = new AddPetResponse();
            var breed = _context.BreedType.FirstOrDefault(b=>b.Name == request.BreedName);
            
            if (breed == null)
            {
                var breed_type = new BreedType()
                {
                    IdBreedType = _context.Pet.Max(p=>p.IdBreedType)+1,
                    Name = request.BreedName

                };
                _context.BreedType.Add(breed_type);
                
            }

            var pet = new Pet()
            {
                IdPet = _context.Pet.Max(p => p.IdPet) + 1,
                Name = request.Name,
                IsMale = request.IsMale,
                DateRegistered = request.DateRegistered,
                ApproximateDateOfBirth = request.ApproximatedDateOfBirth

            };
            _context.Pet.Add(pet);
            response.BreedName = request.BreedName;
            response.Name = pet.Name;
            response.IsMale = pet.IsMale;
            response.DateRegistered = pet.DateRegistered;
            response.ApproximatedDateOfBirth = pet.ApproximateDateOfBirth;
            _context.SaveChanges();
            return response;
        }
    }
}
