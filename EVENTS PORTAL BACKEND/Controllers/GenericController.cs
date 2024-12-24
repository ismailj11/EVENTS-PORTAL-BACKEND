using EP_BLL.Services.GenericServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using EP_BLL.Wrapping.Exceptions;

namespace EVENTS_PORTAL_BACKEND.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GenericController<Dto> : Controller where Dto : class
    {
        public readonly IGenericService<Dto> _service;

        public GenericController(IGenericService<Dto> service)
        {
            _service = service;
        }


        [HttpPost("Add")]
        public ApiResponse<Dto> Add(Dto dto)
        {
            if (dto == null)
            {
                throw new ValidationException("DTO is not null");
            }

            return _service.Add(dto);
        }

        [HttpPut("Update")]
        public ApiResponse<Dto> Update(Dto dto)
        {
            if (dto == null)
            {
                throw new ValidationException("DTO cannot be null");
            }

            return _service.Update(dto);
        }

        [HttpDelete("DeleteById")]
        public ApiResponse<bool> DeleteById(int id)
        {
            return _service.Delete(id);
        }

        [HttpDelete("Delete")]
        public ApiResponse<bool> Delete(Dto dto)
        {
            if (dto == null)
            {
                throw new ValidationException("DTO cannot be null");
            }

            return _service.Delete(dto);
        }

        [HttpGet("GetAll")]
        public ApiResponse<IEnumerable<Dto>> GetAll()
        {



            return _service.GetAll();
        }

        [HttpGet("GetById")]
        public ApiResponse<Dto> GetById(int id)
        {
            return _service.GetById(id);
        }

    }
}
