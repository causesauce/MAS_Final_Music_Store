using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.DTOs
{
    public class InstrumentDto
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public DateTime DateLastPurchase { get; set; }
    }
}
