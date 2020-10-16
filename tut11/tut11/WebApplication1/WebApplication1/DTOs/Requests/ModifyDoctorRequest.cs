using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Requests
{
    public class ModifyDoctorRequest
    {
        [Required(ErrorMessage ="You have to provide id")]
        public int IdDoctor{ get; set; }
        [Required(ErrorMessage = "You have to provide first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You have to provide last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You have to provide email")]
        public string Email { get; set; }
    }
}
