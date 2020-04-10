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
                com.CommandText = "select * FROM studies WHERE Name=@Name";
                com.Parameters.AddWithValue("Name", request.Studies);
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                com.Transaction = transaction;

                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    transaction.Rollback();
                    return BadRequest("there is no such study");
                   
                }
                int idStudy = (int)dr["idStudy"];
                dr.Close();

                
                com.CommandText = "select * From enrollment WHERE semester = 1 AND idStudy=@idStudy";
                com.Parameters.AddWithValue("idStudy", idStudy);
                dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    com.CommandText = "SELECT MAX(idEnrollment) 'idEnrollment' FROM enrollment";
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
                    transaction.Rollback();
                    return BadRequest("there is already a student with such index number");
                }
                else
                {
                    dr.Close();
                    com.CommandText = "insert INTO student values (@IndexNumber, @FirstName, @LastName, @BirthDate, @idEnroll)";
                    com.Parameters.AddWithValue("FirstName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("BirthDate", request.Birthdate);
                    com.Parameters.AddWithValue("idEnroll", idEnrollment);
                    com.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            
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
                        com.CommandText = "PromoteStudent";
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

