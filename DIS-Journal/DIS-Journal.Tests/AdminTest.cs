using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIS_Admin;
using System.Collections.Generic;
using System.Linq;


namespace DIS_Journal.Tests
{
    [TestClass]
    public class AdminTest
    {
        public List<User> users = new List<User>();
        public List<User> GetAllUsers() => users.ToList();

        public User GetUser(int id) => users.Single(x => x.Id == id);

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            users.Remove(user);
        }

        public bool Login(string email, string password)
        {
            var userss = users.Where(e => (e.Email == email || e.Username == email) && e.Password == password && e.Role == "admin").ToArray();
            if (userss.Length != 0)
            {
                User user = userss[0];
                Admin.Id = user.Id;
                Admin.Username = user.Username;
                Admin.Email = user.Email;
                Admin.Password = user.Password;
                Admin.Birth = user.Birth;
                Admin.Role = user.Role;
                return true;
            }
            return false;
        }

        [TestMethod]
        public void TestGettingAllUsers()
        {
            User u = new User(); 
            u.Id = 1;
            u.Username = "testtest";
            u.Email = "test@test.test";
            u.Password = "test";
            u.Birth = new DateTime(2005, 4, 3);
            u.Role = "user";
            users.Add(u);

            User u2 = new User();
            u2.Id = 2;
            u2.Username = "22testtest";
            u2.Email = "22test@test.test";
            u2.Password = "22test";
            u2.Birth = new DateTime(2015, 4, 3);
            u2.Role = "user";
            users.Add(u2);

            Assert.IsNotNull(GetAllUsers());
        }

        [TestMethod]
        public void TestGettingOneUser()
        {
            TestGettingAllUsers();
            User user = GetUser(1);
            Assert.IsNotNull(user);
        }
    }
}
