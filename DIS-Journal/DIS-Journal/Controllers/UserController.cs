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

        public void Register(string username, string email, string password, DateTime birth, string role)
        {
            //making new object to class User - the new object is the new user
            var usersWithSameEmail = context.Users.Where(x => x.Email == email).ToList();
            if (usersWithSameEmail.Count > 0)
            {
                MessageBox.Show("An user with that email exists!");
                return;
            }
            var usersWithSameUsername = context.Users.Where(x => x.Username == username).ToList();
            if (usersWithSameUsername.Count > 0)
            {
                MessageBox.Show("An user with that username exists!");
                return;
            }
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = Hash(password),
                Birth = birth,
                Role = role
            };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show($"Успешна регистрация!");
        }

        public bool Login(string email, string password)
        {
            password = Hash(password);
            //searching for users with the same email and password
            var users = context.Users.Where(e => (e.Email == email || e.Username == email) && e.Password == password).ToArray();
            if (users.Length != 0)
            {
                User user = users[0];
                Logged.Id = user.Id;
                Logged.Username = user.Username;
                Logged.Email = user.Email;
                Logged.Password = user.Password;
                Logged.Birth = user.Birth;
                Logged.Role = user.Role;
                //setting user's subjects
                ScheduleController.Start();
                return true;
            }
            return false;
        }

        public void Update(int id, string username, string password)
        {
            //finnding the user who wants to edit his information
            User user = context.Users.Single(e => e.Id == id);
            user.Username = username;
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
            Logged.Username = null;
            Logged.Email = null;
            Logged.Password = null;
            Logged.Birth = new DateTime();
            Logged.Role = null;
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
