using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIS_Journal.Models;
namespace DIS_Journal
{
    //The class Logged saves the information about the logged user
    static class Logged
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static DateTime Birth { get; set; }
        public static string Role { get; set; }
    }
}
