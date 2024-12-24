using EP_BLL.Dto.Users;
using EP_BLL.Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;
namespace EP_BLL.Services.UserServices
{
    public interface IUserService : IGenericService<UserDto>
    {
        ApiResponse<UserDto> GetUserByUsername(string username);
    }
}
