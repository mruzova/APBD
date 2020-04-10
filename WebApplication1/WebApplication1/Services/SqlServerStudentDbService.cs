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


        EnrollStudentResponse response = null;


        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
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
                    throw new Exception("there is no such study");///..
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

                    throw new Exception("student with such index number is already exists");
                }
                else
                {
                    dr.Close();
                    com.CommandText = "INSERT INTO student VALUES (@IndexN, @FirstName, @LastName, @BirthDate, @idEnroll)";
                    com.Parameters.AddWithValue("IndexN", request.IndexNumber);
                    com.Parameters.AddWithValue("FirstName", request.FirstName);
                    com.Parameters.AddWithValue("LastName", request.LastName);
                    com.Parameters.AddWithValue("BirthDate", request.Birthdate);
                    com.Parameters.AddWithValue("idEnroll", idEnrollment);
                    com.ExecuteNonQuery();
                }
                dr = com.ExecuteReader();
                dr.Read();
                response = new EnrollStudentResponse();
                response.Semester = "1";
                response.LastName = dr["LastName"].ToString();
                dr.Close();
                tran.Commit();
                ///tran.Rollback();
            }
            //return
            return response;
        }

        public IActionResult PromoteStudents(int semester, string studies)
        {
            return Ok();
        }
    }
}

