using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Calendar
    {
        private List<Event> _events;
        private int _daysInMonth;

        public List<Event> Events
        {
            get
            {
                return this._events;
            }
        }

        public int DaysInMonth
        {
            get
            {
                return this._daysInMonth;
            }
        }

        public Calendar()
        {
            this._events = new List<Event>();
            this._daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        public void AddEvent(Event e)
        {
            this._events.Add(e);
        }

        public void AddEvent(DateTime date, string title, string description)
        {
            this._events.Add(new Event(date, title, description));
        }

        public void RemoveEvent(Event e)
        {
            this._events.Remove(e);
        }

        public void RemoveEvent(DateTime date, string title)
        {
            Event e = this._events.Find(x => x.DateTime == date && x.Title == title);
            RemoveEvent(e);
        }
    }
}
