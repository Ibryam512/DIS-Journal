﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DIS_Journal.Models;

namespace DIS_Journal.Controllers
{
    static class ScheduleController
    {
        public static Subject[,] schedule = new Subject[5, 7];
        public static List<Subject> subjects = new List<Subject>();

        public static void AddSubject(string title, Color color)
        {
            if(subjects.Any(x => x.Title == title))
            {
                throw new Exception("The subject already exsists");
            }
            else
            {
                subjects.Add(new Subject(title, 1, 1, 1));
            }
        }

        public static void AddClass(Subject subject, int dayOfTheWeek, int period)
        {
            if (schedule[dayOfTheWeek, period] != default(Subject))
            {
                throw new Exception("There's already a class there!");
            }
            else
            {
                schedule[dayOfTheWeek, period] = subject;
            }
        }

        public static void AddClass(string title, int dayOfTheWeek, int period)
        {
            Subject s = subjects.Find(x => x.Title == title);
            AddClass(s, dayOfTheWeek, period);
        }

        public static void RemoveSubject(string title)
        {
            Subject subject = subjects.Find(x => x.Title == title);
            subjects.Remove(subject);
            for(int i = 0; i < 8; i++)
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
            if (schedule[dayOfTheWeek - 1, period - 1] == default(Subject))
            {
                throw new ArgumentException("There isn't a class there");
            }
            else
            {
                schedule[dayOfTheWeek - 1, period - 1] = default(Subject);
            }
        }
    } 
}
