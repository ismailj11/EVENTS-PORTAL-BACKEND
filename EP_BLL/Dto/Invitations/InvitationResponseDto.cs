using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.Invitations
{
    public class InvitationResponseDto
    {
        public string QRCodeBase64 { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
