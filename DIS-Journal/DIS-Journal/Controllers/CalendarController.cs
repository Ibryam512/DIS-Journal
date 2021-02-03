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
        public static Calendar calendar;

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

        public void ChangeEvent(Event e, string property_to_be_changed, string change_to)
        {
            Event to_be_changed = calendar.Events.Find(x => x == e);
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
                    if(change_to == "Weekly" || change_to == "Daily")
                    {
                        Interval interval;
                        if(change_to == "Daily")
                        {
                            interval = Interval.Daily;
                        }
                        else
                        {
                            interval = Interval.Weekly;
                        }
                        to_be_changed.Repeatedness = interval;
                        DayOfWeek day = to_be_changed.DateTime.DayOfWeek;
                        ScheduleController.AddEvent(to_be_changed);
                        calendar.Events.Remove(to_be_changed);
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
                    }
                    break;
                default:
                    throw new ArgumentException("Event doesn't support that property");
            }
        }
    }
}
