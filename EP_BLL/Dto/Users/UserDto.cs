using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.Users
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int FkRoleId { get; set; }

        public DateTime CreatedAt { get; set; }


        public DateTime? LastLogin { get; set; }

    }
}
