
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task7.Models;

namespace Task7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public StudentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();
            list.Add(new Student
            {
                IdStudent = 1,
                FirstName="Jan",
                LastName = "Kowalski"
            });
            list.Add(new Student
            {
                IdStudent=2,
                FirstName="Andrzej",
                LastName = "Malewski"
            });
            return Ok("list");
        }
        [HttpPost]
        public IActionResult Login(LoginRequestDto request)
        {
         //hashing function
         
            //one-way func
         //hash(a) = kifiyddsssuyfulgih;oj';strdtufuhpok
            //check the password in db

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "jan123"),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );
            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()

            });
        }
        [HttpPost("refresh-token/{token}")]
        public IActionResult RefreshToken(string requestToken)
        {
            //check in db if refresh token exists
            //the rest is the same as above
            return Ok();
        }
        }
}
