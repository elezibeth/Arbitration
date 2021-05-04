using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class CountDownViewModel
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        public TimeSpan GetTimeRemaining(DateTime dueDate)
        {
            
        
            TimeSpan span = dueDate - DateTime.Now;
            Days = span.Days;
            Hours = span.Hours;
            Minutes = span.Minutes;
            Seconds = span.Minutes;
            TimeSpan span2 = new TimeSpan(Days, Hours, Minutes, Seconds);
            return span2;
        }
    }
}
