using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal
{
    class Event
    {
        private DateTime _dateTime;
        private string _title;
        private string _description;
        private Interval _repeatedness;

        public DateTime DateTime
        {
            get
            {
                return this._dateTime;
            }
            set
            {
                this._dateTime = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The title of the event cannot be empty");
                }
                else
                {
                    this._title = value;
                }
            }
        }

        public string Description //optional IMOO
        {
            get
            {
                return this._description;
            }
            set
            {
                if(value.Length < 200)
                {
                    this._description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The description can't be over 200 symbols");
                }
            }
        }

        public Interval Repeatedness
        {
            get
            {
                return this._repeatedness;
            }
            set
            {
                this._repeatedness = value;
            }
        }

        public Event(DateTime dateTime, string title, string description, Interval repeatedness)
        {
            this.DateTime = dateTime;
            this.Title = title;
            this.Description = title;
            this.Repeatedness = repeatedness;
        }

        public override string ToString()
        {
            return $"{this._title}";
        }
    }

    public enum Interval
    {
        //once a
        Once,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
}
