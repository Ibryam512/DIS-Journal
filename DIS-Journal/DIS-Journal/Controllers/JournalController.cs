using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIS_Journal.Models;

namespace DIS_Journal.Controllers
{
    class JournalController
    {
        DisDbContext context = new DisDbContext();
        public void UploadJournal(string title, string description, DateTime date)
        {
            var journal = new Journal()
            {
                Title = title,
                Description = description,
                Date = date,
                User = Logged.Id
            };
            context.Journals.Add(journal);
            context.SaveChanges();
        }

        public List<Journal> GetJournals() => context.Journals.Where(x => x.User == Logged.Id).ToList();

        public Journal GetJournal(string title) => GetJournals().Single(x => x.Title == title);
       
    }
}
