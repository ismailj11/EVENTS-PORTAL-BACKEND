using EP_BLL.Dto.Users;
using EP_BLL.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequestDto loginRequestDto)
        {
            if (loginRequestDto == null || string.IsNullOrEmpty(loginRequestDto.Username) || string.IsNullOrEmpty(loginRequestDto.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var response = _authService.login(loginRequestDto.Username, loginRequestDto.Password);

            if (!response.Success)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(new { Data = response.Data, Message = response.ErrorMessage });
        }
    }
}
