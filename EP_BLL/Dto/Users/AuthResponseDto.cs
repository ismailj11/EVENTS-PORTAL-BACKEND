using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.Users
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
