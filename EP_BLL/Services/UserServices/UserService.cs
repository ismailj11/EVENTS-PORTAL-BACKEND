using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EP_BLL.Dto.Users;
using EP_BLL.Services.GenericServices;
using EP_BLL.Wrapping.Exceptions;
using EP_DAL.Models;
using EP_DAL.Repositories.Users;
namespace EP_BLL.Services.UserServices
{
    public class UserService : GenericService<User, UserDto>, IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ApiResponse<UserDto> GetUserByUsername(string username)
        {
            var response = new ApiResponse<UserDto>();
            var result = _userRepository.GetUserByUsername(username);
            response.Data = _mapper.Map<UserDto>(result);



            return response;


        }

    }
}
