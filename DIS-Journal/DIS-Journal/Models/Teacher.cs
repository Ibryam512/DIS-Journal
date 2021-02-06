using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Teacher : User
    {
        public string Role
        {
            get => "teacher";
        }
    }
}
