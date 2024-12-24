using AutoMapper;
using EP_DAL.Repositories.GenericRepository;
using EP_DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;

namespace EP_BLL.Services.GenericServices
{
    public class GenericService<Entity, Dto> : IGenericService<Dto>
      where Entity : class
      where Dto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        private IUserRepository userRepository;
        private IMapper mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public ApiResponse<Dto> GetById(int id)
        {
            var response = new ApiResponse<Dto>();
            try
            {
                var result = _repository.GetById(id);
                response.Data = _mapper.Map<Dto>(result);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }

        public ApiResponse<IEnumerable<Dto>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<Dto>>();
            try
            {
                var result = _repository.GetAll();
                response.Data = _mapper.Map<IEnumerable<Dto>>(result);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }


        public ApiResponse<Dto> Add(Dto dto)
        {
            var response = new ApiResponse<Dto>();
            try
            {
                var entity = _mapper.Map<Entity>(dto);
                var result = _repository.Add(entity);
                response.Data = _mapper.Map<Dto>(result);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }

        public ApiResponse<Dto> Update(Dto dto)
        {
            var response = new ApiResponse<Dto>();
            try
            {
                var entity = _mapper.Map<Entity>(dto);
                var result = _repository.Update(entity);
                response.Data = _mapper.Map<Dto>(result);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }

        public ApiResponse<bool> Delete(int id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                response.Data = _repository.Delete(id);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }

        public ApiResponse<bool> Delete(Dto dto)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var entity = _mapper.Map<Entity>(dto);
                response.Data = _repository.Delete(entity);
                response.Success = true;
                response.ReasonPhrase = "Operation completed successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.ReasonPhrase = "Error occurred during operation";
                throw new ValidationException(ex.Message);
            }
            return response;
        }
    }
}
