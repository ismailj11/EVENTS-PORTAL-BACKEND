using EP_BLL.Mapping;

namespace EVENTS_PORTAL_BACKEND.Extensions
{
    public static class AutoMapperExtension
    {

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection service)
        {
            service.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }, typeof(Program));

            return service;

        }


    }
}
