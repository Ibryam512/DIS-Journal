using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Schedule
    {
        private Dictionary<DayOfWeek, List<Event>> _scheduledEvents;

        public Dictionary<DayOfWeek, List<Event>> ScheduledEvents
        {
            get
            {
                return this._scheduledEvents;
            }
        }

        public Schedule() //I'm too sleepy idk what I am doing I will check it later
        {
            this._scheduledEvents = new Dictionary<DayOfWeek, List<Event>>();
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek))) //idk if it will run
            {
                this._scheduledEvents.Add(day, new List<Event>());
            }
        }
        
        public void AddEvent(Event e) //prob won't need overload
        {
            if(e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    this._scheduledEvents[day].Add(e);
                    this._scheduledEvents[day] = this._scheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if(e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                this._scheduledEvents[day].Add(e);
                this._scheduledEvents[day] = this._scheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
        }

        public void RemoveEvent(Event e)
        {
            if (e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    this._scheduledEvents[day].Remove(e); //returns bool?
                    this._scheduledEvents[day] = this._scheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if (e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                this._scheduledEvents[day].Remove(e);
                this._scheduledEvents[day] = this._scheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
        }

        public List<Event> EventsForTheDay(DayOfWeek day)
        {
            return this._scheduledEvents[day];
        }
    }
}
