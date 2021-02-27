using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Controllers
{
    class JournalController
    {

        public static Journal journal = new Journal();
        private static List<Journal> titles = new List<Journal>();


        public void AddTitle(string title)
        {
            Journal.titles.Add(title);
        }

        public void AddDescription(string description)
        {

        }

        public void ChangeTitle(string title)
        {

        }

        public void ChangeDescription(string title)
        {

        }
    }
}
