using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [MinLength(2, ErrorMessage = "Event Place cannot be less than 2")]
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public HashSet<TeamEvent> TeamEvents { get; set; } = new();
        public HashSet<EventInstrument> EventInstruments { get; set; } = new();

    }
}
