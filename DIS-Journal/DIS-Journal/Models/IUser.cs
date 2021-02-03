using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get;  }
        string Password { get; }
        DateTime Birth { get; }
        string Role { get; }
    }
}
