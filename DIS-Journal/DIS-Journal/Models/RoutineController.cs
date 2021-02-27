using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class RoutineController
    {
        public static Routine routine = new Routine();
        private static List<Routine> morning_routine = new List<Routine>();
        private static List<Routine> noon_routine = new List<Routine>();
        private static List<Routine> evening_routine = new List<Routine>();

        public void AddMorningRoutine(string routine1)
        {
            Routine.morning_routine.Add(routine1);
        }

        public void AddNoonRoutine(string routine2)
        {
            Routine.noon_routine.Add(routine2);
        }


        public void AddEveningRoutine(string routine3)
        {
            Routine.evening_routine.Add(routine3);
        }

        public void RemoveRoutine1()
        {
            routine.Morning_routine.Remove(routine1);
        }

        public void RemoveRoutine2()
        {
            routine.Noon_routine.Remove(routine2);
        }

        public void RemoveRoutine3()
        {
            routine.Eveninh_routine.Remove(routine3);
        }
    }
}
