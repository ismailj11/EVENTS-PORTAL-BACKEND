using AutoMapper;
using EP_BLL.Dto.Events;
using EP_BLL.Services.GenericServices;
using EP_DAL.Models;
using EP_DAL.Repositories.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;
namespace EP_BLL.Services.EventServices
{
    public class EventService : GenericService<Event, EventDto>, IEventService
    {
        public readonly IEventRepository _eventRepository;
        public readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper) : base(eventRepository, mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public ApiResponse<EventDto> GetEventByName(string name)
        {
            var response = new ApiResponse<EventDto>();
            var result = _eventRepository.GetEventByName(name);
            response.Data = _mapper.Map<EventDto>(result);



            return response;

        }
        public async Task<ApiResponse<IEnumerable<EventDto>>> GetEventByUserId(int id)
        {
            var response = new ApiResponse<IEnumerable<EventDto>>();
            var result = await _eventRepository.GetEventByUserId(id);
            response.Data = _mapper.Map<IEnumerable<EventDto>>(result);

            return response;

        }



        public async Task<ApiResponse<IEnumerable<EventDto>>> SearchEventsAsync(string name, string category)
        {
            var response = new ApiResponse<IEnumerable<EventDto>>();
            try
            {
                var events = await _eventRepository.SearchEventsAsync(name, category);
                response.Data = _mapper.Map<IEnumerable<EventDto>>(events);
                response.Success = true;
                response.ReasonPhrase = "Search completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during search";
            }
            return response;
        }





    }

}
