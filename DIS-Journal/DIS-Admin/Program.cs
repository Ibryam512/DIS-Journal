using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Admin
{
    class Program
    {
        static AdminController adminController = new AdminController();
        static void Main(string[] args)
        {

            Login();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0].ToLower() != "end")
            {
                switch (command[0])
                {
                    case "GetAll":
                        GetAllUsers();
                        break;
                    case "GetUser":
                        GetUser(int.Parse(command[1]));
                        break;
                    case "Delete":
                        DeleteUser(int.Parse(command[1]));
                        Console.WriteLine("Successfully deleted!");
                        GetAllUsers();
                        break;
                    case "Clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("This command is unknown!");
                        break;
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine("Goodbye!");
            Admin.Id = 0;
            Admin.Username = "";
            Admin.Email = "";
            Admin.Password = "";
            Admin.Birth = new DateTime();
            Admin.Role = "";
            Console.Clear();
            Login();

        }

        public static void GetAllUsers()
        {
            foreach (var user in adminController.GetAllUsers())
            {
                Console.WriteLine($"{user.Id} {user.Username} {user.Email}");
            }
        }

        public static void GetUser(int id)
        {
            var user = adminController.GetUser(id);
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Username);
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Birth.ToString());
            Console.WriteLine(user.Role);
        }
        
        public static void DeleteUser(int id)
        {
            adminController.DeleteUser(id);
        }

        public static bool Login(string email, string password)
        {
            if (adminController.Login(email, password))
            {
                Console.WriteLine($"Welcome {Admin.Username}.");
                return true;
            }
            Console.WriteLine("Wrong email/username or password!");
            return false;
        }

        public static void Login()
        {
            bool logged = false;
            do
            {
                Console.Write("Login: ");
                string[] commands = Console.ReadLine().Split().ToArray();
                logged = Login(commands[0], commands[1]);
            }
            while (!logged);
        }
    }
}
