using Microsoft.EntityFrameworkCore.Internal;
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
    public class StudentServiceDb : IStudentServiceDb
    {
        public s18822Context _context { get; set; }
        public StudentServiceDb(s18822Context context)
        {
            _context = context;
        }

 
        public List<Student> GetStudents() 
        {
            var students = _context.Student.ToList();
            return students;
        }

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            var study = _context.Studies.FirstOrDefault(s => s.Name == request.Studies);
            if (study == null)
            {
                throw new Exception("There is no such study");
            }
            var enrollment = _context.Enrollment.Where(enr => enr.IdStudy == study.IdStudy && enr.Semester == 1).FirstOrDefault();
            if (enrollment == null)
            {
                enrollment = new Enrollment()
                {
                    IdEnrollment = _context.Enrollment.Max(enr => enr.IdEnrollment) + 1,
                    Semester = 1,
                    IdStudy = study.IdStudy,
                    StartDate = DateTime.Now
                 };
                _context.Enrollment.Add(enrollment);
            }

            if(_context.Student.FirstOrDefault(s=>s.IndexNumber == request.IndexNumber) != null)
            {
                throw new Exception("Student with such index number already exists");
            }

            var student = new Student()
            {
                IndexNumber = request.IndexNumber,
                BirthDate = request.Birthdate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdEnrollment = enrollment.IdEnrollment
            };
            _context.Student.Add(student);
            var response = new EnrollStudentResponse()
            {
                Semester = enrollment.Semester,
                LastName = student.LastName
            };
            _context.SaveChanges();
            return response;
        }

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request)
        {

            var study = _context.Studies.FirstOrDefault(s=> s.Name==request.Name);
            if (study == null)
            {
                throw new Exception("There is no such study");
            }
        

            var idStudy = _context.Studies.FirstOrDefault(s => s.Name==request.Name).IdStudy;
     
            var enrollment = _context.Enrollment.FirstOrDefault(en => en.Semester == request.Semester && en.IdStudy == idStudy);
            if (enrollment == null)
            {
                throw new Exception("there are no students to promote");
            }
            var res = _context.Enrollment.Where(enr => enr.Semester == request.Semester).ToList();
            res.ForEach(e =>
            {
                e.Semester = request.Semester + 1;
               
            });
            var response = new PromoteStudentResponse()
            {
                Semester =request.Semester+1,
                Name = request.Name
            };
            _context.SaveChanges();
            return response;
        }

        public Student ModifyStudent(ModifyStudentRequest request)
        {
            var student = _context.Student.Find(request.IndexNumber);
            if(student == null)
            {
                throw new Exception("no such student");
            }
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.BirthDate = request.Birthdate;
            _context.SaveChanges();
            return student;
        }

        public Student DeleteStudent(DeleteStudentRequest request)
        {
            var student = _context.Student.Find(request.IndexNumber);
            if (student == null)
            {
                throw new Exception("no such student");
            }
            _context.Remove(student);
            _context.SaveChanges();
            return student;
        }
    }
}
