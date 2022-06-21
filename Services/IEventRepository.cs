using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        Event UpdateEvent(int id, Event event1);
        Event CreateEvent(Event event1);
        bool RemoveEvent(int id);
    }
}
