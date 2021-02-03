using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIS_Journal.Models;

namespace DIS_Journal.Controllers
{
    class CalendarController
    {
        public Calendar calendar;

        public void AddEvent(Event e)
        {
            if (e.Repeatedness == Interval.Once || e.Repeatedness == Interval.Monthly || e.Repeatedness == Interval.Yearly)
            {
                calendar.Events.Add(e);
            }
        }

        public void AddEvent(DateTime date, string title, string description, Interval period)
        {
            if (period == Interval.Once || period == Interval.Monthly || period == Interval.Yearly)
            {                                                                                     
                calendar.Events.Add(new Event(date, title, description, period));
            }
        }

        public void RemoveEvent(Event e)
        {
            calendar.Events.Remove(e);
        }

        public void RemoveEvent(DateTime date, string title)
        {
            Event e = calendar.Events.Find(x => x.DateTime == date && x.Title == title);
            RemoveEvent(e);
        }
    }
}
