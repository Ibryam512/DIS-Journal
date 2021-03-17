using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using DIS_Journal.Controllers;
using DIS_Journal.Models;
using DIS_Journal.Views;
using System.Linq;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class ScheduleTest
    {
        [TestMethod]
        public void TestAddSubject()
        {
            string name = "Subject";
            Color c = Color.AliceBlue;
            ScheduleController.AddSubject(name, c);
            Assert.IsTrue(ScheduleController.context.Subjects.Any(x => x.Title == name && Color.FromArgb(255, x.R, x.G, x.B) == c));
        }
    }
}
