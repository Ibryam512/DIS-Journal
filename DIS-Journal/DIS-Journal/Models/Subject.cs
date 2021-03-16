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

        public int R
        {
            get; set;
        }

        public int G
        {
            get; set;
        }

        public int B
        {
            get; set;
        }

        public int User
        {
            get; set;
        }
        public Subject(string title, int r, int g, int b, int user)
        {
            this.Title = title;
            this.R = r;
            this.G = g;
            this.B = b;
            this.User = user;
        }
    }
}
