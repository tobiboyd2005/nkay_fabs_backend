using AutoMapper;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Conversation, ConversationDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.LastMessage, opt => opt.Ignore())
                .ForMember(dest => dest.UnreadCount, opt => opt.Ignore());

            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender.Username))
                .ForMember(dest => dest.SenderRole, opt => opt.MapFrom(src => src.Sender.Role.ToString()));

            CreateMap<CreateMessageDto, Message>()
                .ForMember(dest => dest.SenderId, opt => opt.Ignore())
                .ForMember(dest => dest.ConversationId, opt => opt.Ignore())
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(_ => false));
        }
    }
}