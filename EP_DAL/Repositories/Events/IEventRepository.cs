using EP_DAL.Models;
using EP_DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.Events
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Event GetEventByName(string name);
        Task<IEnumerable<Event>> SearchEventsAsync(string name, string category);


        Task<IEnumerable<Event>> GetEventByUserId(int id);


    }
}
