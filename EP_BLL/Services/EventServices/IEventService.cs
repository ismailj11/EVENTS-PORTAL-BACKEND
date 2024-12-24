using EP_BLL.Dto.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;
using EP_BLL.Services.GenericServices;
namespace EP_BLL.Services.EventServices
{
    public interface IEventService : IGenericService<EventDto>
    {
        ApiResponse<EventDto> GetEventByName(string name);
        Task<ApiResponse<IEnumerable<EventDto>>> SearchEventsAsync(string name, string category);

        Task<ApiResponse<IEnumerable<EventDto>>> GetEventByUserId(int id);

    }
}
