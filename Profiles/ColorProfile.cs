using AutoMapper;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>(); // Mapper to map from Color entity to ColorDto
            CreateMap<CreateColorDto, Color>(); // Mapper to map from CreateColorDto to Color entity
            CreateMap<UpdateColorDto, Color>(); // Mapper to map from UpdateColorDto to Color entity>
        }
    }
}
