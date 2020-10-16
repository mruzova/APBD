using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
    }
}
