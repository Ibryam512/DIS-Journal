using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Student : User
    {
        public Student(string firstName, string lastName, string email, string password, int age) : base(firstName, lastName, email, password, age, "student")
        { }
    }
}
