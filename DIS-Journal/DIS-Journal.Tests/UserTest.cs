using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIS_Journal.Controllers;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestLogin()
        {
            var userController = new UserController();
            Assert.IsTrue(userController.Login("a@a.a", "111111"));
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
