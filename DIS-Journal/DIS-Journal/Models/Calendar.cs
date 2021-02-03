using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Calendar
    {
        private List<Event> _events;
        private int _daysInMonth;

        public List<Event> Events
        {
            get
            {
                return this._events;
            }
        }

        public int DaysInMonth
        {
            get
            {
                return this._daysInMonth;
            }
        }

        public Calendar()
        {
            this._events = new List<Event>();
            this._daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }
    }
}
