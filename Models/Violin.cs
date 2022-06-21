using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Violin : StringInstrument
    {
        public bool HasReplacementString { get; set; }
        public bool ShoulderRest { get; set; }

        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (Violin)instrument;
            HasReplacementString = instrumentCasted.HasReplacementString;
            ShoulderRest = instrumentCasted.ShoulderRest;
        }
    }
}
