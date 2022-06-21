using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class TeamEventRepository : ITeamEventRepository
    {
        private readonly Context _context;
        public TeamEventRepository(Context context)
        {
            _context = context;
        }

        public TeamEvent CreateTeamEvent(TeamEvent teamEvent)
        {
            var newTeamEvent = new TeamEvent()
            {
                DutiesDesc = teamEvent.DutiesDesc,
                EventId = teamEvent.EventId,
                TeamId = teamEvent.TeamId
            };

            _context.TeamEvents.Add(newTeamEvent);
            _context.SaveChanges();
            return newTeamEvent;
        }

        public List<TeamEvent> GetAllTeamEvents()
        {
            return _context.TeamEvents.ToList();
        }

        public TeamEvent GetTeamEventById(int id)
        {
            return _context.TeamEvents.Where(te => te.TeamEventId == id).FirstOrDefault();
        }

        public bool RemoveTeamEvent(int id)
        {
            var teamEvent = GetTeamEventById(id);
            if (teamEvent is null)
            {
                return false;
            }

            _context.TeamEvents.Remove(teamEvent);
            _context.SaveChanges();
            return true;
        }

        public TeamEvent UpdateTeamEvent(int id, TeamEvent teamEvent)
        {
            var editedTeamEvent = GetTeamEventById(id);
            if (editedTeamEvent is null)
            {
                return null;
            }

            editedTeamEvent.DutiesDesc = teamEvent.DutiesDesc;
            editedTeamEvent.EventId = teamEvent.EventId;
            editedTeamEvent.TeamId = teamEvent.TeamId;

            _context.SaveChanges();
            return editedTeamEvent;
        }
    }
}
