using EP_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_DAL.Repositories.GenericRepository;

namespace EP_DAL.Repositories.Users
{

    using Entity = User;
    public class UserRepository : GenericRepository<Entity>, IUserRepository

    {
        public UserRepository(EventsPortalDbContext eventsPortalDbContext) : base(eventsPortalDbContext) { }

        public Entity GetUserByUsername(string username)
        {
            return _dbSet.Where(x => x.Username == username).FirstOrDefault();



        }



    }
}
