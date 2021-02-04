using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Schedule
    {
        private Dictionary<DayOfWeek, List<Event>> events;

        public Dictionary<DayOfWeek, List<Event>> Events
        {
            get
            {
                return this.events;
            }
        }

        public Schedule()
        {
            this.events = new Dictionary<DayOfWeek, List<Event>>();
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek))) //idk if it will run
            {
                this.events.Add(day, new List<Event>());
            }
        }
    }
}
