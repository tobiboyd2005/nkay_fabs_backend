using Microsoft.AspNetCore.JsonPatch;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Services
{
    public interface IFabricInfoRepository
    {
        // imported endpoint logic from /FabricInfoRepository
        Task<IEnumerable<Fabric>> GetFabricsAsync();
        Task<Fabric?> GetFabricAsync(int fabricId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Color>> GetColorsAsync();
        Task<Color?> GetColorAsync(int colorId);
        Task CreateFabric(Fabric newFabric);
        void DeleteFabric(Fabric fabric);
        Task CreateCategory(CreateCategoryDto newCategory);
        Task DeleteCategory(int categoryId);
        Task CreateColor(CreateColorDto newColor);
        Task DeleteColor(int colorId);
        Task<bool> SaveChangesAsync();

    }
}
