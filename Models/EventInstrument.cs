using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class EventInstrument
    {
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public int InstrumentId { get; set; }
        public Instrument InstrumentIdNavigation { get; set; }
        public int EventId { get; set; }
        public Event EventIdNavigation { get; set; }
    }
}
