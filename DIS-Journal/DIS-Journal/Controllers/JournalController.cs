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
        public static Journal journal = new Journal();

        public void AddTitle(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("The title can't be empty!");
            }
            //else
               // journal.titles.Add(title);

            /* if(journal.Title != "")
             {journal.titles.Add(title);}
             */
        }
        public void AddDescription(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("The description can't be empty!");
            }
            //else
                //journal.descriptions.Add(description);

            /* if(journal.Description != "")
             {journal.descriptions.Add(description);}
             */
        }
    }
}
