using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DIS_Journal.Models;
using DIS_Journal.Views;

namespace DIS_Journal.Tests
{
    [TestClass]
    public class JournalTest
    {
        List<Journal> journals = new List<Journal>();
        public void UploadJournal(string title, string description, DateTime date)
        {
            var journalsWithSameTitle = journals.Where(x => x.Title == title && x.User == Logged.Id).ToList();
            if (journalsWithSameTitle.Count > 0)
            {
                var message = new CustomBox("There is a journal with the same title!");
                message.ShowDialog();
                return;
            }
            var journal = new Journal()
            {
                Title = title,
                Description = description,
                Date = date,
                User = Logged.Id
            };
            journals.Add(journal);
        }

        public List<Journal> GetJournals() => journals.Where(x => x.User == Logged.Id).ToList();

        public Journal GetJournal(string title) => GetJournals().Single(x => x.Title == title);

// -------------------------------------------------------------- tests ---------------------------------------------------------------

        [TestMethod]

        public void TestAddJournalEntry()
        {
            DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            UploadJournal("title", "lorem ipsum dolar ti simens", date);
            Assert.IsTrue(journals.Any(x => x.Date == date));
        }

        [TestMethod]
        
        public void TestAddJourneySameName()
        {
            TestAddJournalEntry();
            DateTime date = new DateTime(2009, 5, 1, 8, 30, 52);
            UploadJournal("title", "test test", date);
            Assert.IsTrue(journals.Find(x => x.Title == "title").Description == "lorem ipsum dolar ti simens");
        }

        [TestMethod]

        public void TestGetJournalEntries()
        {
            TestAddJournalEntry();
            Assert.IsTrue(GetJournals().Count != 0);
        }

        [TestMethod]

        public void TestGetZeroJournalEntries()
        {
            Assert.IsTrue(GetJournals().Count == 0);
        }

        [TestMethod]

        public void TestGetSpecificJournalEntries()
        {
            UploadJournal("titleOf1", "lorem ipsum", new DateTime(2009, 5, 1, 8, 30, 52));
            UploadJournal("titleOf2", "lorem ipsum dolar ti simens" , new DateTime(2019, 5, 1, 8, 30, 52));
            Journal j = GetJournal("titleOf1");
            Assert.IsTrue(journals.Find(x => x.Description == "lorem ipsum").Title == j.Title);
        }
    }
}
