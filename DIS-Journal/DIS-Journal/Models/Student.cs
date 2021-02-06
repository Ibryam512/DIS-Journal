using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Student : User
    {
        public string Role
        {
            get => "student";
        }
    }
}
