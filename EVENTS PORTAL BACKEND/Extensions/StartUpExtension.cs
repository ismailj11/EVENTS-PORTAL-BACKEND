using EP_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EVENTS_PORTAL_BACKEND.Extensions
{
    public static class StartUpExtension
    {

        public static IServiceCollection addDb(this IServiceCollection service, ConfigurationManager config)
        {

            var ConnectionString = config.GetConnectionString("DefaultConnection");

            service.AddDbContext<EventsPortalDbContext>(options =>
                            options.UseSqlServer(ConnectionString)








                            );

            return service;




        }




    }
}
