using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Teacher : User
    {
        public Teacher(string firstName, string lastName, string email, string password, int age) : base(firstName, lastName, email, password, age, "teacher")
        { }
    }
}
