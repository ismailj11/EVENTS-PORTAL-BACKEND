using AutoMapper;
using EP_BLL.Dto.Invitations;
using EP_BLL.Services.EmailServices;
using EP_BLL.Services.QrCodeServices;
using EP_DAL.Models;
using EP_DAL.Repositories.Invitations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Services.InvitationServices
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly QRCodeGeneratorService _qrCodeGeneratorService;
        private readonly EmailSender _emailSender;
        private readonly IMapper _mapper;

        public InvitationService(
            IInvitationRepository invitationRepository,
            QRCodeGeneratorService qrCodeGeneratorService,
            EmailSender emailSender,
            IMapper mapper)
        {
            _invitationRepository = invitationRepository;
            _qrCodeGeneratorService = qrCodeGeneratorService;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<InvitationResponseDto> CreateAndSendInvitationAsync(CreateInvitationDto dto)
        {

            var invitation = _mapper.Map<Invitation>(dto);

            await _invitationRepository.AddInvitationAsync(invitation);


            var qrCodeBase64 = await _qrCodeGeneratorService.GenerateQRCodeAsync(invitation.InvitationId);


            var emailBody = ConstructEmailBody(dto.Name, dto.FkEventId, qrCodeBase64);


            await _emailSender.SendEmailAsync(dto.Email, "You're Invited!", emailBody);


            return new InvitationResponseDto
            {
                QRCodeBase64 = qrCodeBase64,
                Message = "Invitation created and email sent successfully."
            };
        }

        private string ConstructEmailBody(string name, int eventId, string qrCodeBase64)
        {
            return $@"
                <html>
                    <body>
                        <p>Dear {name},</p>
                        <p>You have been invited to Event ID {eventId}. Please use the QR code below for attendance:</p>
                        <img src='data:image/png;base64,{qrCodeBase64}' alt='QR Code' />
                    </body>
                </html>";
        }
    }
}
