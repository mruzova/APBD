using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.DAL;
using Task3.Models;

using System.Data.SqlClient;


namespace Task3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student>();
           
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True"))
            {
                using(var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "select firstname, lastname, birthdate,  name, semester from student, enrollment, studies where student.idenrollment = enrollment.idenrollment and studies.idstudy = enrollment.idstudy";
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while(dr.Read())
                    {
                        var st = new Student();
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();
                        st.BirthDate = dr["BirthDate"].ToString();
 
                        st.enrollment = new Enrollment
                        {
                            Semester = (int)(dr["Semester"]),
                            study = new Study { Name = dr["Name"].ToString() }
                        };
                        students.Add(st);
                        
                    }
                }
            }
            return Ok(students);
        }

        [HttpGet("{IndexNumber}")]
        public IActionResult GetStudentEnrollment(string IndexNumber)
        {

            var en = new Enrollment();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True"))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "select semester from student, enrollment, studies where student.idenrollment = enrollment.idenrollment and studies.idstudy = enrollment.idstudy and indexNumber=@indexNumber";
                    com.Parameters.AddWithValue("indexNumber", IndexNumber);
                    con.Open();
                    var dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                         en.Semester = (int)(dr["Semester"]);
                       
                    }
                    else{
                        return Ok("no such student");
                    }
                   
                }
            }
            return Ok(en);
        }
    
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Updated");
        }
    [HttpPost]
    public IActionResult CreateStudent(Student s)
        {
            int number = new Random().Next(1, 20000);
            s.IndexNumber = "s" + number;
            return Ok(s);
        }
}
}
