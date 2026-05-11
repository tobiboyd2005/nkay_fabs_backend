using AutoMapper;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>(); // Mapper to map from Category entity to CategoryDto
            CreateMap<CreateCategoryDto, Category>(); // Mapper to map from CreateCategoryDto to Category entity
            CreateMap<UpdateCategoryDto, Category>(); // Mapper to map from UpdateCategoryDto to Category entity
        }
    }
}
