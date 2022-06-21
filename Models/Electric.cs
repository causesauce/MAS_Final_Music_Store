using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public abstract class Electric : Instrument, IElectric
    {
        [Range(0, 400)]
        public int Voltage { get; set; }

        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (Electric)instrument;
            Voltage = instrumentCasted.Voltage;
        }
    }
}
