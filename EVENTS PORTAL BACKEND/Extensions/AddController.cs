
using EVENTS_PORTAL_BACKEND.Filters;

namespace EVENTS_PORTAL_BACKEND.Extensions
{
    public static class AddControllers
    {

        public static IServiceCollection AddController(this IServiceCollection Services)
        {
            Services.AddControllers(options =>
            {
                options.Filters.Add(new GlobalExceptionFilter());
            });
            return Services;
        }
    }
}
