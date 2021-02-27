using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Models;

namespace DIS_Journal.Controllers
{
    class UserController
    {
        DisDbContext context = new DisDbContext();

        public void Register(string firstName, string lastName, string email, string password, DateTime birth, string role)
        {
            //making new object to class User - the new object is the new user
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = Hash(password),
                Birth = birth,
                Role = role
            };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show($"Успешна регистрация!");
        }

        public void Login(string email, string password)
        {
            password = Hash(password);
            //searching for users with the same email and password
            var users = context.Users.Where(e => e.Email == email && e.Password == password).ToArray();
            if (users.Length != 0)
            {
                User user = users[0];
                Logged.Id = user.Id;
                Logged.FirstName = user.FirstName;
                Logged.LastName = user.LastName;
                Logged.Email = user.Email;
                Logged.Password = user.Password;
                Logged.Birth = user.Birth;
                Logged.Role = user.Role;
                MessageBox.Show($"{Logged.FirstName}, влязохте успешно!");
            }

        }

        public void Update(int id, string firstName, string lastName, string password)
        {
            //finnding the user who wants to edit his information
            User user = context.Users.Single(e => e.Id == id);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = Hash(password);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            //finnding the user who wants to delete his account
            User user = context.Users.Single(e => e.Id == id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void Logout()
        {
            Logged.Id = 0;
            Logged.FirstName = "";
            Logged.LastName = "";
            Logged.Email = "";
            Logged.Password = "";
            Logged.Birth = new DateTime();
            Logged.Role = "";
        }

        private string Hash(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            string hashedPassword = new ASCIIEncoding().GetString(md5data);
            return hashedPassword;
        }
    }
}
