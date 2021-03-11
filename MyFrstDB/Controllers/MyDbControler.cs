using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyFrstDB.Models;
namespace MyFrstDB.Controllers
{
    [ApiController]
    [Route("Student")]
    public class MyDbControler : ControllerBase
    {
        
      
        [HttpGet]
        public IActionResult GetStudents()
        {
            IEnumerable<Student> students;
            using (var dbContext = new StudentContext())
            {
                students = dbContext.students.ToList();
            }

            return Ok(students);
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbContext = new StudentContext())
            {
                dbContext.students.Add(student);
                dbContext.SaveChanges();
            }
            return Created("", student);
        }
        [HttpPut]
        public IActionResult EditStudent([FromBody] Student student)
        {
           // "swagger"
            using (var dbContext = new StudentContext())
            {
                var studentToEdit = dbContext.students.Find(student.Id);
                if (studentToEdit == null)
                {
                    return BadRequest();
                }
                studentToEdit.Name = student.Name;
                studentToEdit.LastName = student.LastName;
                studentToEdit.Age = student.Age;
                
                dbContext.students.Update(studentToEdit);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }

   
}
