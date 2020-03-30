using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_3.Models;

namespace Tutorial_3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent = 1, FirstName = "Jan", LastName = "K"},
                new Student{IdStudent = 2, FirstName = "Anna", LastName = "M"},
                new Student{IdStudent = 3, FirstName = "Andrey", LastName = "A"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }       
    }
}
