using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Wrapping.Exceptions
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public string ErrorMessage { get; set; }


        public string ReasonPhrase { get; set; }
        public ApiResponse()
        {
            Success = true;
            Errors = new List<string>();
        }
        public ApiResponse(T obj)
        {
            Data = obj;
            Success = true;

        }

    }
}
