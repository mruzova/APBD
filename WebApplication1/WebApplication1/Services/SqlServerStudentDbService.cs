//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication1.DTOs.Requests;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.DTOs.Responses;

//namespace WebApplication1.Services
//{
//    public class SqlServerStudentDbService : ControllerBase, IStudentServiceDb
//    {
//        int idEnroll=0;
//        public IActionResult EnrollStudent(EnrollStudentRequest request)
//        {
//            //1. Validation - OK
//            //2. Check if studies exists -> 404
//            //3. Check if enrollment exists -> INSERT
//            //4. Check if index does not exists -> INSERT/400
//            //5. return Enrollment model

//            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True"))
//            using (var com = new SqlCommand())
//            {
//                com.Connection = con;
//                com.CommandText = "SELECT * FROM Studies WHERE Name=@Name";
//                com.Parameters.AddWithValue("Name", request.Studies);


//                con.Open();
//                SqlTransaction tran = con.BeginTransaction();
//                com.Transaction = tran;
//                //2. EXECUTE THE 1 statement
//                var dr = com.ExecuteReader();
//                if (!dr.Read())
//                {
//                    dr.Close();
//                    tran.Rollback();
//                    return BadRequest("there is no such study");///...
//                    //ERROR - 404 - Studies does not exists
//                }
//                //   dr.Close();
//                int idStudy = (int)dr["IdStudy"];
//                dr.Close();
//                //3.
//                com.CommandText = "SELECT * FROM Enrollment WHERE Semester=1 AND IdStudy=@idStudy";
//                com.Parameters.AddWithValue("IdStudy", idStudy);
//                dr = com.ExecuteReader();
//                if (!dr.Read())
//                {
//                    dr.Close();
//                }
//                else
//                {
//                    dr.Close();
//                    com.CommandText = "select max(idenrollment) as 'idEnrollment' from enrollment";
//                    dr = com.ExecuteReader();
//                    dr.Read();
//                    idEnroll = (int)dr["idEnrollment"] + 1;

//                    dr.Close();
//                    com.CommandText = "INSERT INTO enrollment (idEnrollment, Semester, IdStudy, StartDate) VALUES (" + idEnroll + " ,1, @IdStudy, '" + DateTime.Now + "')";
//                    com.Parameters.AddWithValue("idEnrollment", idEnroll);
//                    com.ExecuteNonQuery();

//                }

//                dr.Close();
//                //4. ....
//                com.CommandText = "select * from student where indexNumber=@IndexNumber";
//                com.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
//                dr = com.ExecuteReader();


//                if (dr.Read())
//                {
//                    dr.Close();
//                    tran.Rollback();
//                    return BadRequest("student with such index number is already exists");

//                }
//                else
//                {
//                    dr.Close();
//                    com.CommandText = "INSERT INTO Student VALUES (@IndexNumber, @FirstName, @LastName, @BirthDate, @idEnrollment)";
//                    com.Parameters.AddWithValue("FirstName", request.FirstName);
//                    com.Parameters.AddWithValue("LastName", request.LastName);
//                    com.Parameters.AddWithValue("BirthDate", request.Birthdate);

//                    com.ExecuteNonQuery();

//                }

//                //...


//                tran.Commit();
//                ///tran.Rollback();
//            }
//            return Ok("New student with index number: " + request.IndexNumber + " is enrolled");
//        }

//        public IActionResult PromoteStudents(int semester, string studies)
//        {
//            return Ok();
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Responses;


namespace WebApplication1.Services
{
    public class SqlServerStudentDbService : ControllerBase, IStudentServiceDb
    {

        int idEnrollment;




        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM studies WHERE Name=@Name";
                com.Parameters.AddWithValue("Name", request.Studies);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                com.Transaction = tran;


                var dr = com.ExecuteReader();



                if (!dr.Read())
                {
                    dr.Close();
                    tran.Rollback();
                    return BadRequest("there is no such study");///...
                    //ERROR - 404 - Studies does not exists
                }
                //   dr.Close();
                int idStudy = (int)dr["IdStudy"];
                dr.Close();


                com.CommandText = "SELECT * FROM enrollment WHERE semester = 1 AND idStudy=@idStudy";
                com.Parameters.AddWithValue("idStudy", idStudy);
                dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    com.CommandText = "SELECT MAX(idEnrollment) as 'idEnrollment' FROM enrollment";
                    dr = com.ExecuteReader();
                    dr.Read();
                    idEnrollment = (int)dr["idEnrollment"] + 1;
                    dr.Close();
                    com.CommandText = "INSERT INTO enrollment  (idEnrollment, Semester, IdStudy, StartDate)  VALUES (@idEnrollment, 1, @idStudy, '" + DateTime.Now + "')";
                    com.Parameters.AddWithValue("idEnrollment", idEnrollment);

                    com.ExecuteNonQuery();
                }
                dr.Close();

                com.CommandText = "SELECT * FROM student WHERE IndexNumber=@IndexNumber";
                com.Parameters.AddWithValue("IndexNumber", request.IndexNumber);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    tran.Rollback();
                    return BadRequest("student with such number already exists");
                }
                else
                {
                    dr.Close();
                    com.CommandText = "INSERT INTO student VALUES (@IndexNumber, @FirstName, @LastName, @BirthDate, @idEnroll)";
                    com.Parameters.AddWithValue("FirstName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("BirthDate", request.Birthdate);
                    com.Parameters.AddWithValue("idEnroll", idEnrollment);
                    com.ExecuteNonQuery();
                }
                tran.Commit();
            }
            //return
            return Ok("New student with index number: " + request.IndexNumber + " is enrolled");
        }

        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
         
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18822;Integrated Security=True"))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "PromoteStudent";
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("Name", request.Name);

                    com.Parameters.AddWithValue("Semester", request.Semester);
                    var dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        com.CommandText = "PromoteStudents";
                        com.CommandType = System.Data.CommandType.StoredProcedure;

                       
                            request.Name = dr["Name"].ToString();
                            request.Semester = (int)dr["Semester"];

                        
                    }
                    

                    
                }
            }
            int sem = request.Semester + 1;
            return Ok("Students from semester number " + request.Semester + " are now on " + sem + " semester");
        }
    }
}

