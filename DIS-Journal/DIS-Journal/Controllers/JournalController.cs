using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Models;
using DIS_Journal.Views;

namespace DIS_Journal.Controllers
{
    public class JournalController
    {
        DisDbContext context = new DisDbContext();
        public void UploadJournal(string title, string description, DateTime date)
        {
            var journalsWithSameTitle = context.Journals.Where(x => x.Title == title && x.User == Logged.Id).ToList();
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
            context.Journals.Add(journal);
            context.SaveChanges();
        }

        public List<Journal> GetJournals() => context.Journals.Where(x => x.User == Logged.Id).ToList();

        public Journal GetJournal(string title) => GetJournals().Single(x => x.Title == title);
       
    }
}
