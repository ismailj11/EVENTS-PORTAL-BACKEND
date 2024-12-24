using EP_DAL.Repositories.Events;
using EP_DAL.Repositories.Invitations;
using EP_DAL.Repositories.MarkAttendance;
using EP_DAL.Repositories.Users;

namespace EVENTS_PORTAL_BACKEND.Extensions
{
    public static class repositoryExtension
    {

        public static IServiceCollection AddRepositories(this IServiceCollection Services)
        {

            Services.AddScoped<IUserRepository, UserRepository>();
         
            Services.AddScoped<IEventRepository, EventRepository>();
          
            Services.AddScoped<IInvitationRepository, InvitationRepository>();
            
            Services.AddScoped<IInvitationRepository, InvitationRepository>();
            Services.AddScoped<IMarkAttendancerepository, MarkAttendancerepository>();
           



            return Services;
        }



    }
}
