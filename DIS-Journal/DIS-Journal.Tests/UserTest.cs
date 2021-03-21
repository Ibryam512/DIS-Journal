using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIS_Journal;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using DIS_Journal.Controllers;
using DIS_Journal.Models;
using DIS_Journal.Views;
using System.Linq;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class UserTest
    {
        public List<User> users = new List<User>();

        public void Register(string username, string email, string password, DateTime birth, string role)
        {
            //making new object to class User - the new object is the new user
            var usersWithSameEmail = users.Where(x => x.Email == email).ToList();
            if (usersWithSameEmail.Count > 0)
            {
                var message = new CustomBox("An user with that email exists!");
                message.ShowDialog();
                return;
            }
            var usersWithSameUsername = users.Where(x => x.Username == username).ToList();
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
            users.Add(user);
            var congrats = new CustomBox("Congrats", "You registered successfully!");
            congrats.ShowDialog();
        }

        public bool Login(string email, string password)
        {
            password = Hash(password);
            //searching for users with the same email and password
            var userss = users.Where(e => (e.Email == email || e.Username == email) && e.Password == password).ToArray();
            if (userss.Length != 0)
            {
                User user = userss[0];
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
            User user = users.Single(e => e.Id == id);
            user.Username = username;
            Logged.Username = username;
        }

        public void Delete(int id)
        {
            //finnding the user who wants to delete his account and deleting all his journals, classes and subjects
            //List with id-s of all the subjects the user added
            List<Journal> journals = new List<Journal>();
            List<int> subjects = new List<int>();
            List<Class> classes = new List<Class>();
            List<Subject> subjects1 = new List<Subject>();
            User user = users.Single(e => e.Id == id);
            users.Remove(user);
            foreach (var journal in journals.Where(x => x.User == id))
                journals.Remove(journal);
            foreach (var subject in subjects1.Where(x => x.User == id))
            {
                subjects.Add(subject.Id);
                subjects1.Remove(subject);
            }
            foreach (var sid in subjects)
            {
                foreach (var subject in classes.Where(x => x.Subject == sid))
                {
                    classes.Remove(subject);
                }
            }
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

        [TestMethod]
        public void TestRegister()
        {
            Register("test1", "test1@test.test", "password", new DateTime(), "user");
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void TestLogin()
        {
            TestRegister();
            Assert.IsTrue(Login("test1", "password"));
        }
        
        [TestMethod]
        public void TestUpdate()
        {
            TestRegister();
            Update(0, "test4e");
            Assert.AreEqual("test4e", users[0].Username);
        }

        [TestMethod]
        public void TestDeleteAndLogout()
        {
            TestRegister();
            Delete(0);
            Assert.AreEqual(0, Logged.Id);
        }
        [TestMethod]
        public void TestHash()
        {
            string password = "password";
            string hashed = Hash(password);
            Assert.AreNotEqual(hashed, password);
        }
    }
}
