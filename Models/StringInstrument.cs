using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public abstract class StringInstrument : Instrument
    {
        [Range(0, 20)]
        public int StringsNum { get; set; }
        [MinLength(2, ErrorMessage = "Contract Content cannot be less than 2 chanracters")]
        public string Material { get; set; }
        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (StringInstrument)instrument;
            StringsNum = instrumentCasted.StringsNum;
            Material = instrumentCasted.Material;
        }
    }
}
