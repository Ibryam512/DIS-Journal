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
            Console.WriteLine("Type 'Help' for the commands!");
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
                        GetAllUsers();
                        break;
                    case "Clear":
                        Console.Clear();
                        break;
                    case "Help":
                        Console.WriteLine("GetAll - gets all users");
                        Console.WriteLine("GetUser {id} - gets the user with the given id");
                        Console.WriteLine("Delete {id} - deletes the user with the given id");
                        Console.WriteLine("Clear - clears the console");
                        Console.WriteLine("End - logs out the logged admin");
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
            if (Admin.Id == id)
            {
                Console.WriteLine("You can't delete your account!");
                return;
            }
            adminController.DeleteUser(id);
            Console.WriteLine("Successfully deleted!");
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
