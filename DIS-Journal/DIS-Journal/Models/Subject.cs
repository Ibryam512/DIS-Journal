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
        public string Title
        {
            get; set;
        }

        public Color Color
        {
            get; set;
        }

        public Subject(string title, Color color)
        {
            this.Title = title;
            this.Color = color;
        }
    }
}
