using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIS_Admin;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void TestGettingAllUsers()
        {
            Admin.Id = 8;
            var controller = new AdminController();
            List<User> users = controller.GetAllUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void TestGettingOneUser()
        {
            Admin.Id = 8;
            var controller = new AdminController();
            User user = controller.GetUser(3);
            Assert.IsNotNull(user);
        }
    }
}
