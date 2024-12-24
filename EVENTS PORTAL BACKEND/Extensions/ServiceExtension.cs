using EP_BLL.Services.AuthServices;
using EP_BLL.Services.EventServices;
using EP_BLL.Services.InvitationServices;
using EP_BLL.Services.MarkAttendance;
using EP_BLL.Services.QrCodeServices;
using EP_BLL.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EVENTS_PORTAL_BACKEND.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IUserService, UserService>();
           
            services.AddScoped<IEventService, EventService>();
          
            services.AddScoped<IInvitationService, InvitationService>();
          
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<QRCodeGeneratorService>();
            services.AddScoped<IMarkAttendanceService, MarkAttendanceService>();
           
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))




                    };
                });





            return services;
        }
    }
}
