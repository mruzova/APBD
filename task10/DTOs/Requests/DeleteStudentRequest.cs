using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task10.DTOs.Requests
{
    public class DeleteStudentRequest
    {
        [Required(ErrorMessage = "You have to provide index number")]
        public string IndexNumber { get; set; }
    }
}
