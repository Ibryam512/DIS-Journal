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
    }
}
