using EP_DAL.Models;
using EP_DAL.Repositories.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;


namespace EP_BLL.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ApiResponse<string> login(string userName, string password)
        {
            try
            {
                var user = userRepository.GetUserByUsername(userName);
                if (user == null)
                {
                    return new ApiResponse<string>
                    {
                        Success = false,
                        ErrorMessage = "Username not found"
                    };
                }

                if (user.Password != password)
                {
                    return new ApiResponse<string>
                    {
                        Success = false,
                        ErrorMessage = "Wrong password"
                    };
                }

                else
                {
                    var token = Generate(user);
                    return new ApiResponse<string>
                    {

                        Success = true,
                        Data = token,
                        ErrorMessage = "Authenticated succesfully"
                    };
                }


            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    Success = false,
                    ErrorMessage = $"An error occurred: {ex.Message}"
                };
            }
        }

        private string Generate(User user)
        {



            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.UserId.ToString()),
                 new Claim("Email", user.Email.ToString()),

            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}
