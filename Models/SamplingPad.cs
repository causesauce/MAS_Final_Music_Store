using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class SamplingPad : Electric
    {
        [Range(0, 49)]
        public int NumberOfSquares { get; set; }
        [MinLength(2, ErrorMessage = "SamplingPad Input cannot be less than 2 characters")]
        public string Input { get; set; }

        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (SamplingPad)instrument;
            NumberOfSquares = instrumentCasted.NumberOfSquares;
            Input = instrumentCasted.Input;
        }

    }
}
