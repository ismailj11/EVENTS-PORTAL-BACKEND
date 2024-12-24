using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.Invitations
{
    public class CreateInvitationDto
    {


        public int FkEventId { get; set; }

        public int FkUserId { get; set; }

        public bool? AttendanceStatus { get; set; }

        public DateTime InvitedAt { get; set; } = DateTime.UtcNow;

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;




    }
}
