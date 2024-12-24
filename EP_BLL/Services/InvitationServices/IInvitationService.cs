using EP_BLL.Dto.Invitations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Services.InvitationServices
{
    public interface IInvitationService
    {
        Task<InvitationResponseDto> CreateAndSendInvitationAsync(CreateInvitationDto dto);
    }
}
