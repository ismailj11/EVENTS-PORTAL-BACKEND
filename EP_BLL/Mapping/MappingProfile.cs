using AutoMapper;
using EP_BLL.Dto.Events;
using EP_BLL.Dto.Invitations;
using EP_BLL.Dto.MarkAttendance;
using EP_BLL.Dto.Users;
using EP_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

       
            CreateMap<User, UserDto>().ReverseMap();
           
            CreateMap<Event, EventDto>().ReverseMap();
            
     

            CreateMap<CreateInvitationDto, Invitation>().ReverseMap();
            CreateMap<Invitation, MarkAttendanceDto>().ReverseMap();


            CreateMap<User, LoginRequestDto>().ReverseMap();
            CreateMap<Invitation, InvitationResponseDto>().ReverseMap();
            
        }
    }
}
