using EP_BLL.Dto.Users;
using EP_BLL.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using EP_BLL.Wrapping.Exceptions;
namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : GenericController<UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [HttpGet("GetUserByName")]
        public ApiResponse<UserDto> GetUserByNames(string name)
        {
            return _userService.GetUserByUsername(name);


        }
    }
}
