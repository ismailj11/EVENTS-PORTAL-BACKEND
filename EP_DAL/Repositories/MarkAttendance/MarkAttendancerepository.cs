using EP_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.MarkAttendance
{
    public class MarkAttendancerepository : IMarkAttendancerepository
    {
        private readonly EventsPortalDbContext _context;

        public MarkAttendancerepository(EventsPortalDbContext context)
        {
            _context = context;





        }
        public async Task<Invitation> GetInvitationByIdAsync(int invitationId)
        {
            return await _context.Invitations.FirstOrDefaultAsync(i => i.InvitationId == invitationId);
        }

        public async Task UpdateAttendancerepStatusAsync(int invitationId, bool attendanceStatus, DateTime attendedAt)
        {
            var invitation = await GetInvitationByIdAsync(invitationId);
            if (invitation != null)
            {
                invitation.AttendanceStatus = attendanceStatus;
                invitation.AttendedAt = attendedAt;
                _context.Invitations.Update(invitation);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
