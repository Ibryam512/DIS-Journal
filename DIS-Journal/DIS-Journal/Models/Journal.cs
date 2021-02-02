using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Journal
    {
        private string title;
        private DateTime date;
        private string description;

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title of the event cannot be empty");
                }
                else
                {
                    this.title = value;
                }
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public Journal(string title, DateTime date, string description)
        {
            this.Date = date;
            this.Title = title;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"";
        }


    }
}
