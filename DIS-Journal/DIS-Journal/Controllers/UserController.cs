using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Models;
using DIS_Journal.Views;

namespace DIS_Journal.Controllers
{
    public class UserController
    {
        DisDbContext context = new DisDbContext();

        public void Register(string username, string email, string password, DateTime birth, string role)
        {
            //making new object to class User - the new object is the new user
            var usersWithSameEmail = context.Users.Where(x => x.Email == email).ToList();
            if (usersWithSameEmail.Count > 0)
            {
                var message = new CustomBox("An user with that email exists!");
                message.ShowDialog();
                return;
            }
            var usersWithSameUsername = context.Users.Where(x => x.Username == username).ToList();
            if (usersWithSameUsername.Count > 0)
            {
                var message = new CustomBox("An user with that username exists!");
                message.ShowDialog();
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
                return true;
            }
            return false;
        }

        public void Update(int id, string username)
        {
            //finnding the user who wants to edit his information
            User user = context.Users.Single(e => e.Id == id);
            user.Username = username;
            Logged.Username = username;
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            //finnding the user who wants to delete his account and deleting all his journals, classes and subjects
            //List with id-s of all the subjects the user added
            List<int> subjects = new List<int>();
            User user = context.Users.Single(e => e.Id == id);
            context.Users.Remove(user);
            foreach (var journal in context.Journals.Where(x => x.User == id))
                context.Journals.Remove(journal);
            foreach (var subject in context.Subjects.Where(x => x.User == id))
            {
                subjects.Add(subject.Id);
                context.Subjects.Remove(subject);
            }
            foreach (var sid in subjects)
            {
                foreach (var subject in context.Classes.Where(x => x.Subject == sid))
                {
                    context.Classes.Remove(subject);
                }
            }
            context.SaveChanges();
            Logout();
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

        public string Hash(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            string hashedPassword = new ASCIIEncoding().GetString(md5data);
            return hashedPassword;
        }
    }
}
