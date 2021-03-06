using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    interface IUser
    {
        string UserName { get; set; }
        string Email { get;  }
        string Password { get; }
        DateTime Birth { get; }
        string Role { get; }
    }
}
