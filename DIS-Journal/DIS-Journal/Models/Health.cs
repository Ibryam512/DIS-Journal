using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Health
    {
        //private string exercices;
        private List<string> excercices;
        private List<string> pills;
        private List<Health> meals; //eventualno da se razpredelqt po dni i vid???
        //private string sleep;
        private int hour1;  //falling asleep
        private int hour2;  // waking up
        private string description; 
        private string dreams;  //idk man
        private List<string> other_activities;

        public List<string> Excercices
        { get { return this.excercices; } }

        public List<string> Pills
        { get { return this.pills; } }

        public List<string> Meals
        { get { return this.meals; } }

        public List<string> Other_activities
        { get { return this.other_activities; } }

        public int Hour1
        {
            get { return this.hour1; }
            set { this.hour1 = value; }
        }

        public int Hour2
        {
            get { return this.hour2; }
            set { this.hour2 = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description= value; }
        }

        public string Dreams
        {
            get { return this.dreams; }
            set { this.dreams = value; }
        }

        public Health()
        {
            this.excercices = new List<string>();
            this.pills = new List<string>();
            this.meals = new List<string>();
            this.other_activities = new List<string>();
            this.Hour1 = hour1;
            this.Hour2 = hour2;
            this.Dreams = dreams;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
