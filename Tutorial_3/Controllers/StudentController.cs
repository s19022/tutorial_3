using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public IActionResult GetStudent()
        {
            var students = new List<Student>();
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19022;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Student";
                connection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var student = new Student();
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.IndexNumber = dataReader["IndexNumber"].ToString();
                    student.LastName = dataReader["LastName"].ToString();

                    students.Add(student);
                }
            }

            return Ok(students);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetSemester(string indexNumber)
        {
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19022;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select semester from Student s, Enrollment e " +
                                    "where IndexNumber = @indexNumber and s.IdEnrollment = e.idEnrollment";
                command.Parameters.AddWithValue("@indexNumber", indexNumber);
                connection.Open();
                var dataReader = command.ExecuteReader();
                var result = new List<string>();
                while (dataReader.Read())
                {
                    result.Add(dataReader["Semester"].ToString());
                }
                return Ok(result);
            }
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