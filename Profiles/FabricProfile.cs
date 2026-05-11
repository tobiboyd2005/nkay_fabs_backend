using AutoMapper;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Profiles
{
    public class FabricProfile : Profile
    {
        public FabricProfile()
        {
            CreateMap<Fabric, FabricDto>(); // Mapper to map from Fabric entity to FabricDto
            CreateMap<CreateFabricDto, Fabric>(); // Mapper to map from CreateFabricDto to Fabric entity
        }
    }
}
