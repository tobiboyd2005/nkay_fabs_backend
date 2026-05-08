using AutoMapper;

namespace nkay_fabs_backend.Profiles
{
    public class FabricProfile : Profile
    {
        public FabricProfile()
        {
            CreateMap<Entities.Fabric, Models.Dtos.FabricDto>();
        }
    }
}
