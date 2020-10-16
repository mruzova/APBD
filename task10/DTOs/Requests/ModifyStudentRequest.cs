using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task10.DTOs.Requests
{
    public class ModifyStudentRequest
    {    // [RegularExpression("^s[0-9]+$")]
        [Required(ErrorMessage = "You have to provide index number")]
        public string IndexNumber { get; set; }

        [Required(ErrorMessage = "You have to provide first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to provide last name")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "You have to provide birthdate")]
        public DateTime Birthdate { get; set; }

    }
}
