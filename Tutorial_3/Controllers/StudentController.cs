using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial_3.DAL;
using Tutorial_3.Models;

namespace Tutorial_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            return Ok("Update complete " + id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Delete complete " + id);
        }
    }
}