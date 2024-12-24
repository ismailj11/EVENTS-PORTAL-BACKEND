using EP_BLL.Dto.Invitations;
using EP_BLL.Services.InvitationServices;
using Microsoft.AspNetCore.Mvc;

namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> CreateAndSendInvitation(CreateInvitationDto dto)
        {
            try
            {
                var response = await _invitationService.CreateAndSendInvitationAsync(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
