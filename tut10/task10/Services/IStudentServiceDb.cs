using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using task10.DTOs;
using task10.DTOs.Requests;
using task10.DTOs.Responses;
using task10.Models;

namespace task10.Services
{
    public interface IStudentServiceDb
    {
        public List<Student> GetStudents();
         public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
         public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request);
         public Student ModifyStudent(ModifyStudentRequest request);
         public Student DeleteStudent(DeleteStudentRequest request);
        public AddStudentResponse AddStudent(AddStudentRequest request);
    }
}
