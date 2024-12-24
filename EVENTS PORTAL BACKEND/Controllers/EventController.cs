using EP_BLL.Dto.Events;
using EP_BLL.Services.EventServices;
using Microsoft.AspNetCore.Mvc;
using EP_BLL.Wrapping.Exceptions;

namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventController : GenericController<EventDto>
    {
        private readonly IEventService _eventService;
        public EventController(IEventService service) : base(service)
        {
            _eventService = service;
        }

        [HttpGet("GetEventByName")]
        public ApiResponse<EventDto> GetEventByNames(string name)
        {
            return _eventService.GetEventByName(name);


        }


        [HttpGet("GetEventByUserId")]
        public async Task<ApiResponse<IEnumerable<EventDto>>> GetEventByUserId(int id)
        {

            return await _eventService.GetEventByUserId(id);
        }













        [HttpGet("search")]
        public async Task<IActionResult> SearchEvents([FromQuery] string name, [FromQuery] string category)
        {
            var result = await _eventService.SearchEventsAsync(name, category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
