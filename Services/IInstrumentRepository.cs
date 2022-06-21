using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IInstrumentRepository
    {
        List<InstrumentDto> GetAllInstrumentsOwnedByCustomer(int customerId);
        List<Instrument> GetAllInstrumentsByBrand(int brandId);
        List<Instrument> GetAllInstruments();
        Instrument GetInstrumentById(int id);
        Instrument UpdateInstrument(int id, IInstrument instrument);
        Instrument CreateInstrument(IInstrument instrument);
        bool RemoveInstrument(int id);

    }
}
