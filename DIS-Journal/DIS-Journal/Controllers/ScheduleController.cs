using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIS_Journal.Models;

namespace DIS_Journal.Controllers
{
    class ScheduleController
    {
        public static Schedule schedule;

        public static void AddEvent(Event e) //prob won't need overload
        {
            if (e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    schedule.ScheduledEvents[day].Add(e);
                    schedule.ScheduledEvents[day] = schedule.ScheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if (e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                schedule.ScheduledEvents[day].Add(e);
                schedule.ScheduledEvents[day] = schedule.ScheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
        }

        public void RemoveEvent(Event e)
        {
            if (e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    schedule.ScheduledEvents[day].Remove(e); //returns bool?
                    schedule.ScheduledEvents[day] = schedule.ScheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if (e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                schedule.ScheduledEvents[day].Remove(e);
                schedule.ScheduledEvents[day] = schedule.ScheduledEvents[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
        }

        public List<Event> EventsForTheDay(DayOfWeek day)
        {
            return schedule.ScheduledEvents[day];
        }
    }
}
