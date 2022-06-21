using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class EventInstrumentRepository : IEventInstrument
    {

        private readonly Context _context;
        public EventInstrumentRepository(Context context)
        {
            _context = context;
        }

        public EventInstrument CreateEventInstrument(EventInstrument ei)
        {
            var newEventInstrument = new EventInstrument
            {
                Quantity = ei.Quantity,
                InstrumentId = ei.InstrumentId,
                EventId = ei.EventId
            };

            _context.EventInstruments.Add(newEventInstrument);
            _context.SaveChanges();
            return newEventInstrument;
        }

        public List<EventInstrument> GetAllEventInstruments()
        {
            return _context.EventInstruments.ToList();
        }

        public EventInstrument GetEventInstrumentByIds(int eventId, int instrumentId)
        {
            return _context.EventInstruments.Where(ei => ei.EventId == eventId && ei.InstrumentId == instrumentId).FirstOrDefault();
        }

        public bool RemoveEventInstrument(int eventId, int instrumentId)
        {
            var eventInstrument = GetEventInstrumentByIds(eventId, instrumentId);
            if (eventInstrument is null)
            {
                return false;
            }

            _context.EventInstruments.Remove(eventInstrument);
            _context.SaveChanges();
            return true;
        }

        public EventInstrument UpdateEventInstrument(int eventId, int instrumentId, EventInstrument ei)
        {
            var eventInstrument = GetEventInstrumentByIds(eventId, instrumentId);
            if (eventInstrument is null)
            {
                return null;
            }

            eventInstrument.Quantity = ei.Quantity;
            eventInstrument.InstrumentId = ei.InstrumentId;
            eventInstrument.EventId = ei.EventId;

            _context.SaveChanges();
            return eventInstrument;
        }
    }
}
