using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Routine
    {
        private string morning_routine;
        //private List<Routine> morning_routine1;
        private string noon_routine;
        //private List<Routine> noon_routine1;
        private string evening_routine;
        //private List<Routine> evening_routine1;

        

        public string Morning_routine
        { get { return this.morning_routine; } 
          set { this.morning_routine = value; }
        }

        public string Noon_routine
        {
            get { return this.noon_routine; }
            set { this.noon_routine = value; }
        }

        public string Evening_routine
        {
            get { return this.evening_routine; }
            set { this.evening_routine = value; }
        }

        public Routine()
        {
            this.Morning_routine = morning_routine;
            this.Noon_routine = noon_routine;
            this.Evening_routine = evening_routine;
        }

        public override string ToString()
        { 
            return $""; 
        }
    }
}
