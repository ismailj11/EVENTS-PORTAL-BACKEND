
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_BLL.Wrapping.Exceptions;


namespace EP_BLL.Services.AuthServices
{
    public interface IAuthService
    {
        ApiResponse<string> login(string username, string password);
    }
}
