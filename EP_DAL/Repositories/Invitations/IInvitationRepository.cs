using EP_DAL.Models;
using EP_DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_DAL.Repositories.Invitations
{
    public interface IInvitationRepository : IGenericRepository<Invitation>
    {
        Task AddInvitationAsync(Invitation invitation);
        Task<Invitation> GetInvitationWithEventAsync(int invitationId);
    }
}
