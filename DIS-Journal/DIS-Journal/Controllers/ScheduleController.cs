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
        public static Schedule schedule = new Schedule();

        public static void AddEvent(Event e)
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
                case "date":
                    to_be_changed.DateTime = DateTime.Parse(change_to);
                    break;
                case "repetition":
                    if (change_to == "Weekly" || change_to == "Daily")
                    {
                        Interval interval;
                        if (change_to == "Daily")
                        {
                            interval = Interval.Daily;
                        }
                        else
                        {
                            interval = Interval.Weekly;
                        }
                    }
                    else
                    {
                        Interval interval;
                        switch (change_to)
                        {
                            case "Once":
                                interval = Interval.Once;
                                break;
                            case "Monthly":
                                interval = Interval.Weekly;
                                break;
                            case "Yearly":
                                interval = Interval.Yearly;
                                break;
                            default:
                                throw new ArgumentException("Doesn't have that interval in enum");
                        }
                        to_be_changed.Repeatedness = interval;
                        foreach (DayOfWeek d in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                        {
                            if (schedule.Events[d].Contains(to_be_changed))
                            {
                                schedule.Events[d].Remove(to_be_changed);
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Event doesn't support that property");
            }
        }
        public List<Event> EventsForTheDay(DayOfWeek day)
        {
            return schedule.Events[day];
        }
    } 
}
