using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.MarkAttendance
{
    public class MarkAttendanceDto
    {

        public string InvitationId { get; set; }
        public bool? AttendanceStatus { get; set; }
        public DateTime? AttendedAt { get; set; } = DateTime.UtcNow;
    }
}
