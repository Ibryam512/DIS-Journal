using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Controllers
{
    class EventController
    {
        List<Event> events = new List<Event>();

        public void AddEvent(DateTime dateTime, string title, string description, Interval repeatedness)
        {
            Event e = new Event(dateTime, title, description, repeatedness);
            events.Add(e);
        }

        public void DeleteEvent(Event e)
        {
            events.Remove(e);
        }

        public void ChangeEventTitle(Event e, string newTitle)
        {
            Event tobeupdated = events.Find(x => x == e);
            tobeupdated.Title = newTitle;
        }

        public void ChangeEventDescription(Event e, string description)
        {
            Event tobeupdated = events.Find(x => x == e);
            tobeupdated.Description = description;
        }

        public void ChangeEventDate(Event e, DateTime dateTime)
        {
            Event tobeupdated = events.Find(x => x == e);
            tobeupdated.DateTime = dateTime;
        }

        public void ChangeEventRepeatedness(Event e, Interval repeatedness)
        {
            Event tobeupdated = events.Find(x => x == e);
            tobeupdated.Repeatedness = repeatedness;
        }
    }
}
