﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task10.DTOs
{
    public class PromoteStudentRequest
    {
        [Required(ErrorMessage = "You have to provide semester")]
        public int Semester { get; set; }
        [Required(ErrorMessage = "You have to provide name of study")]
        public string Name { get; set; }
    }
}
