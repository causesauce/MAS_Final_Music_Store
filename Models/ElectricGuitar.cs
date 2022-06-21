using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Models
{
    public class ElectricGuitar : StringInstrument, IElectric
    {
        [MinLength(2, ErrorMessage = "ElectricGuitar Input cannot be less than 2 characters")]
        public string Input { get; set; }
        [Range(0, 20)]
        public int SinglesNum { get; set; }
        [Range(0, 20)]
        public int HumbuckersNum { get; set; }
        [Range(0, 400)]
        public int Voltage { get; set; }

        public override void CopyData(IInstrument instrument)
        {
            base.CopyData(instrument);
            var instrumentCasted = (ElectricGuitar)instrument;
            Voltage = instrumentCasted.Voltage;
            Input = instrumentCasted.Input;
            SinglesNum = instrumentCasted.SinglesNum;
            HumbuckersNum = instrumentCasted.HumbuckersNum;
        }

    }
}
