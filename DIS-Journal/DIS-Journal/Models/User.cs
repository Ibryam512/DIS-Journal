using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class User : IUser
    {
        private string a;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public string Role { get; set; }
       
    }
}
