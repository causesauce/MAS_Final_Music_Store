using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IEventInstrument
    {
        List<EventInstrument> GetAllEventInstruments();
        EventInstrument GetEventInstrumentByIds(int eventId, int instrumentId);
        EventInstrument CreateEventInstrument(EventInstrument ei);
        EventInstrument UpdateEventInstrument(int eventId, int instrumentId, EventInstrument ei);
        bool RemoveEventInstrument(int eventId, int instrumentId);
    }
}
