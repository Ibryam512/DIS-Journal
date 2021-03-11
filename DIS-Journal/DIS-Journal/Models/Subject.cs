using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DIS_Journal.Models
{
    class Subject
    {
        public int Id { get; set; }
        public string Title
        {
            get; set;
        }

        public string Color
        {
            get; set;
        }

        public Subject(string title, string color)
        {
            this.Title = title;
            this.Color = color;
        }
    }
}
