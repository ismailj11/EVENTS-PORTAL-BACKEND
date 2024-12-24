using EP_BLL.Dto.MarkAttendance;
using EP_BLL.Services.MarkAttendance;
using Microsoft.AspNetCore.Mvc;

namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkAttendanceController : ControllerBase
    {
        private readonly IMarkAttendanceService _markAttendanceService;

        public MarkAttendanceController(IMarkAttendanceService markAttendanceService)
        {
            _markAttendanceService = markAttendanceService;
        }

        [HttpPost("mark")]
        public async Task<IActionResult> UpdateAttendanceStatus(MarkAttendanceDto dto)
        {
            try
            {
                await _markAttendanceService.UpdateAttendanceStatusAsync(dto);
                return Ok(new { Message = "Attendance status updated successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
