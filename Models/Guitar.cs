using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class Guitar : StringInstrument
    {
        public StringType Type { get; set; }

        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (Guitar)instrument;
            Type = instrumentCasted.Type;
        }
    }
}
