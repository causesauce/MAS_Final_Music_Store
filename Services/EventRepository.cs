using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class EventRepository : IEventRepository
    {

        private readonly Context _context;

        public EventRepository(Context context)
        {
            _context = context;
        }

        public Event CreateEvent(Event event1)
        {
            var newEvent = new Event()
            {
                Place = event1.Place,
                Start = event1.Start,
                Finish = event1.Finish,
                Price = event1.Price
            };

            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return newEvent;
        }

        public List<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _context.Events.Where(e => e.EventId == id).FirstOrDefault();
        }

        public bool RemoveEvent(int id)
        {
            var event1 = GetEventById(id);
            if (event1 is null)
            {
                return false;
            }

            _context.Remove(event1);
            _context.SaveChanges();
            return true;
        }

        public Event UpdateEvent(int id, Event event1)
        {
            var editedEvent = GetEventById(id);
            if (editedEvent is null)
            {
                return null;
            }

            editedEvent.Place = event1.Place;
            editedEvent.Start = event1.Start;
            editedEvent.Finish = event1.Finish;
            editedEvent.Price = event1.Price;

            _context.SaveChanges();
            return editedEvent;
        }
    }
}
