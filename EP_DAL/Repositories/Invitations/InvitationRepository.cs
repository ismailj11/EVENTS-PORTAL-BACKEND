using EP_DAL.Models;
using EP_DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.Invitations
{
    public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
    {
        private readonly EventsPortalDbContext _dbContext;

        public InvitationRepository(EventsPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Invitation> GetInvitationWithEventAsync(int invitationId)
        {
            var invitation = await Task.Run(() => GetById(invitationId));

            if (invitation != null)
            {

                invitation.FkEvent = await _dbContext.Events.FindAsync(invitation.FkEventId);
            }

            return invitation;
        }

        public async Task AddInvitationAsync(Invitation invitation)
        {
            try
            {
                _dbContext.Invitations.Add(invitation);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving invitation: {ex.Message}");
                throw;
            }
        }
    }
}
