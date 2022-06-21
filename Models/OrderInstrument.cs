using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class OrderInstrument
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order OrderIdNavigation { get; set; }
        public int InstrumentId { get; set; }
        public Instrument InstrumentIdNavigation { get; set; }
    }
}
