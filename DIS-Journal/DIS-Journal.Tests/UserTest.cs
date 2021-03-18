using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIS_Journal;
using DIS_Journal.Controllers;
using DIS_Journal.Models;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestRegister()
        {
            var userController = new UserController();
            userController.Register("test1", "test1@test.test", "password", new DateTime(), "user");
            Assert.IsNotNull(userController.context.Users);
        }

        [TestMethod]
        public void TestLogin()
        {
            var userController = new UserController();
            Assert.IsTrue(userController.Login("test", "testtest"));
        }
        
        [TestMethod]
        public void TestUpdate()
        {
            var userController = new UserController();
            userController.Update(1, "test4e");
            Assert.AreEqual("tes4e", Logged.Username);
        }

        [TestMethod]
        public void TestDeleteAndLogout()
        {
            var userController = new UserController();
            userController.Delete(1);
            Assert.AreEqual("", Logged.Username);
        }
        [TestMethod]
        public void TestHash()
        {
            var userController = new UserController();
            string password = "password";
            string hashed = userController.Hash(password);
            Assert.AreNotEqual(hashed, password);
        }
    }
}
