using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Collections.Generic;
using DIS_Journal.Controllers;
using DIS_Journal.Models;
using DIS_Journal.Views;
using System.Linq;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class ScheduleTest
    {
        public static List<Subject> subjects = new List<Subject>();
        public static Subject[,] schedule = new Subject[5, 7];

        public static void AddSubject(string title, Color color, int ln)
        {
            if (subjects.Any(x => x.Title == title))
            {
                var message = new CustomBox("The subject already exsists");
                message.ShowDialog();
                return;
            }
            else
            {
                var subject = new Subject(title, color.R, color.G, color.B, ln);
                subjects.Add(subject);
            }
        }

        public static void AddClass(Subject subject, int dayOfTheWeek, int period)
        {
            if (schedule[dayOfTheWeek, period] != default(Subject))
            {
                var message = new CustomBox("There's already a class there!");
                message.ShowDialog();
                return;
            }
            else
            {
                schedule[dayOfTheWeek, period] = subject;
            }
        }

        public static void AddClass(string title, int dayOfTheWeek, int period)
        {
            Subject s = subjects.Single(x => x.Title == title);
            AddClass(s, dayOfTheWeek, period);
        }

        public static void RemoveSubject(string title)
        {
            Subject subject = subjects.Single(x => x.Title == title);
            subjects.Remove(subject);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (schedule[i, j] == subject)
                    {
                        schedule[i, j] = default(Subject);
                    }
                }
            }
        }

        public static void RemoveClass(int dayOfTheWeek, int period)
        {
            if (schedule[dayOfTheWeek, period] == default(Subject))
            {
                var message = new CustomBox("There isn't a class there");
                message.ShowDialog();
                return;
            }
            else
            {
                schedule[dayOfTheWeek, period] = default(Subject);
            }
        }

// -------------------------------------------------------------- tests ---------------------------------------------------------------
        [TestMethod]

        public void TestAddingSubjects()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            Assert.IsTrue(subjects.Any(x => x.Title == title));
        }
        
        [TestMethod]

        public void TestAddingTheSameSubject()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            AddSubject(title, c, 1);
            Assert.IsTrue(subjects.Count(x => x.Title == title) == 1);
        }
        
        [TestMethod]

        public void TestAddClassViaSubject()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            Subject s = subjects.Find(x => x.Title == "subject");
            AddClass(s, 2, 2);
            Assert.IsTrue(schedule[2, 2] != default(Subject));
        }

        [TestMethod]

        public void TestAddDoubleClassViaSubject()
        {
            TestAddClassViaSubject();
            Color c = Color.Black;
            string title = "title";
            AddSubject(title, c, 5);
            AddClass(subjects.Find(x => x.Title == title), 2, 2);
            Assert.IsTrue(schedule[2, 2] == subjects.Find(x => x.Title == "subject"));
        }

        [TestMethod]

        public void TestAddClassViaTitle()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            AddClass(title, 3, 2);
            Assert.IsTrue(schedule[3, 2] == subjects.Find(x => x.Title == "subject"));
        }

        [TestMethod]

        public void TestAddDoubleClassViaTitle()
        {
            TestAddClassViaTitle();
            Color c = Color.Red;
            string title = "title";
            AddSubject(title, c, 2);
            AddClass(title, 3, 2);
            Assert.IsTrue(schedule[3, 2] == subjects.Find(x => x.Title == "subject"));
        }

        [TestMethod]
        
        public void TestRemoveSubject()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            AddClass(title, 3, 3);
            AddClass(title, 3, 2);
            RemoveSubject(title);
            Assert.IsTrue(schedule[3, 2] == default(Subject) && schedule[3, 3] == default(Subject));
        }

        [TestMethod]

        public void TestRemoveClass()
        {
            string title = "subject";
            Color c = Color.Blue;
            AddSubject(title, c, 1);
            AddClass(title, 3, 3);
            RemoveClass(3, 3);
            Assert.IsTrue(schedule[3, 3] == default(Subject));
        }

        [TestMethod]

        public void TestRemoveClassWithoutAnyClassThere()
        {
            Subject s = schedule[4, 6];
            RemoveClass(4, 6);
            Assert.AreEqual(s, schedule[4, 6]);
        }
    }
}
