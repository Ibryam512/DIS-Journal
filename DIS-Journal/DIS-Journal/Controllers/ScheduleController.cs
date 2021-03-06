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
        //public static Schedule schedule = new Schedule();

        /*public static void AddEvent(Event e)
        {
            if (e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    schedule.Events[day].Add(e);
                    schedule.Events[day] = schedule.Events[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if (e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                schedule.Events[day].Add(e);
                schedule.Events[day] = schedule.Events[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
            else if (e.Repeatedness == Interval.MondayToFriday)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    if(day != DayOfWeek.Saturday || day != DayOfWeek.Sunday)
                    {
                        schedule.Events[day].Add(e);
                    }
                    schedule.Events[day] = schedule.Events[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
        }

        public void RemoveEvent(Event e)
        {
            if (e.Repeatedness == Interval.Daily)
            {
                foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                {
                    schedule.Events[day].Remove(e);
                    schedule.Events[day] = schedule.Events[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
                }
            }
            else if (e.Repeatedness == Interval.Weekly)
            {
                DayOfWeek day = e.DateTime.DayOfWeek;
                schedule.Events[day].Remove(e);
                schedule.Events[day] = schedule.Events[day].OrderBy(x => x.DateTime.TimeOfDay).ToList();
            }
        }

        public void ChangeEvent(Event e, string property_to_be_changed, string change_to)
        {
            DayOfWeek day = e.DateTime.DayOfWeek;
            Event to_be_changed = schedule.Events[day].Find(x => x == e);
            switch (property_to_be_changed)
            {
                case "title":
                    to_be_changed.Title = change_to;
                    break;
                case "description":
                    to_be_changed.Description = change_to;
                    break;
                default:
                    throw new ArgumentException("Schedule events don't support that property");
            }
        }
        public List<Event> EventsForTheDay(DayOfWeek day)
        {
            return schedule.Events[day];
        }*/
    } 
}
