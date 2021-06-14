using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAssignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//token must be valid to use this contr
    //upar wale global hh sabke liye
    public class StudentController : Controller
    {
        StudentDetailsContext _context;



        public StudentController(StudentDetailsContext context)
        {
            _context = context;
        }



        [HttpPost]
        public ActionResult AddUser([FromBody] StudentInfo user)
        {
            try
            {
                _context.StudentInfo.Add(user);//add user in table
                _context.SaveChanges();
                return Ok(new { EmailId=user.Email });
            }
            catch(Exception ex)
            {
                return Ok(new { EmailId = "" });
            }
            
        }

        [HttpGet]
        [Route("{email}")]
        public ActionResult GetUser(string email )//parameter postman see ayega
        {
            var student = _context.StudentInfo.FirstOrDefault(stud => stud.Email == email);
            return Ok(student);
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }
        [HttpDelete("{email}")]
        public ActionResult DeleteStudent(string email)
        {
            var studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Email == email);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{email}")]
        public ActionResult UpdateStudent(string email, [FromBody] StudentInfo studentRequest)
        {
            //note we are not updating email here
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Email == email);
            if(studentInfo!=null)
            {
                studentInfo.FirstName = studentRequest.FirstName;
                studentInfo.LastName = studentRequest.LastName;
                //  studentInfo.Gender = studentRequest.Gender;
                studentInfo.Age = studentRequest.Age;
                studentInfo.City = studentRequest.City;
                studentInfo.Skills = studentRequest.Skills;
                studentInfo.Password = studentRequest.Password;
                _context.StudentInfo.Update(studentInfo);
                _context.SaveChanges();
                return Ok(studentInfo);
            }
            return NotFound(new StudentInfo());
        }


    }
}