using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Requests
{
    public class AddPetRequest
    {
        [Required(ErrorMessage ="Required")]
        public string BreedName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool IsMale { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateRegistered { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime ApproximatedDateOfBirth { get; set; }
    }
}
