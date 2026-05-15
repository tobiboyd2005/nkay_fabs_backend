using AutoMapper;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<CreateNotificationDto, Notification>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ParseNotificationType(src.Type)));

            CreateMap<NotificationType, string>().ConvertUsing(src => src.ToString());
        }

        private static NotificationType ParseNotificationType(string type)
        {
            if (Enum.TryParse<NotificationType>(type, true, out var result))
            {
                return result;
            }
            return NotificationType.System;
        }
    }
}