using EP_DAL.Models;
using EP_DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.Events
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(EventsPortalDbContext context) : base(context) { }

        public Event GetEventByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.EventName == name);
        }

        public async Task<IEnumerable<Event>> GetEventByUserId(int id)
        {
            return await _dbSet.Where(e => e.FkOrganizerId == id).ToListAsync();

        }


        public async Task<IEnumerable<Event>> SearchEventsAsync(string name, string category)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.EventName.Contains(name));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(x => x.Category == category);

            return await query.ToListAsync();
        }


    }
}
