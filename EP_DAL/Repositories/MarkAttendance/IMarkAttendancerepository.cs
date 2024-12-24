using EP_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.MarkAttendance
{
    public interface IMarkAttendancerepository
    {

        Task<Invitation> GetInvitationByIdAsync(int invitationId);
        Task UpdateAttendancerepStatusAsync(int invitationId, bool attendanceStatus, DateTime attendedAt);
        Task SaveChangesAsync();

    }
}
