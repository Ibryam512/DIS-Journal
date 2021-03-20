using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DIS_Journal.Models;
using DIS_Journal.Views;

namespace DIS_Journal.Controllers
{
    public static class ScheduleController
    {
        public static DisDbContext context = new DisDbContext();
        public static List<Subject> subjects = context.Subjects.Where(x => x.User == Logged.Id).ToList();
        public static Subject[,] schedule = new Subject[5, 7];

        public static void Start()
        {
            List<int> subjectIds = new List<int>();
            foreach (var x in subjects) subjectIds.Add(x.Id);
            var classes = context.Classes.Where(x => subjectIds.Contains(x.Subject)).ToList();
            //var subjects = context.Subjects.ToList();
            foreach (var subject in classes)
            {
                schedule[subject.Day, subject.Hour] = subjects.Single(x => subject.Subject == x.Id && x.User == Logged.Id);
            }
        }
        public static void AddSubject(string title, Color color)
        {
            if(subjects.Any(x => x.Title == title))
            {
                var message = new CustomBox("The subject already exsists");
                message.ShowDialog();
                return;
            }
            else
            {
                var subject = new Subject(title, color.R, color.G, color.B, Logged.Id);
                context.Subjects.Add(subject);
                subjects.Add(subject);
                context.SaveChanges();
            }
        }

        public static void AddClass(Subject subject, int dayOfTheWeek, int period)
        {
            if (schedule[dayOfTheWeek, period] != default(Subject))
            {
                var message = new CustomBox("There's already a class there!");
                message.ShowDialog();
                return;
            }
            else
            {
                schedule[dayOfTheWeek, period] = subject;
                var clss = new Class()
                {
                    Day = dayOfTheWeek,
                    Hour = period,
                    Subject = subject.Id
                };
                context.Classes.Add(clss);
                context.SaveChanges();
            }
        }

        public static void AddClass(string title, int dayOfTheWeek, int period)
        {
            Subject s = context.Subjects.Single(x => x.Title == title);
            AddClass(s, dayOfTheWeek, period);
        }

        public static void RemoveSubject(string title)
        {
            Subject subject = context.Subjects.Single(x => x.Title == title);
            context.Subjects.Remove(subject);
            context.SaveChanges();
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(schedule[i, j] == subject)
                    {
                        schedule[i, j] = default(Subject);
                    }
                }
            }
        }

        public static void RemoveClass(int dayOfTheWeek, int period)
        {
            if (schedule[dayOfTheWeek, period] == default(Subject))
            {
                var message = new CustomBox("There isn't a class there");
                message.ShowDialog();
                return;
            }
            else
            {
                schedule[dayOfTheWeek, period] = default(Subject);
                var clss = context.Classes.Single(x => x.Day == dayOfTheWeek && x.Hour == period);
                context.Classes.Remove(clss);
                context.SaveChanges();
            }
        }
    } 
}
