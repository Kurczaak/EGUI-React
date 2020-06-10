using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Event
    {
        public String eventDescription { get; set; }

        public DateTime eventDate { get; set; }

        public string eventTime1 { get; set; }

        public string eventTime2 { get; set; }
    }
}
