using System;
using System.Collections.Generic;
using Tutorial_3.Models;

namespace Tutorial_3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
