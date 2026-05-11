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
        Task PartialUpdateFabric(int fabricId, JsonPatchDocument<UpdateFabricDto> patchDoc); 
        Task DeleteFabric(int fabricId);
        Task CreateCategory(CreateCategoryDto newCategory);
        Task UpdateCategory(int categoryId, UpdateCategoryDto newCategory);
        Task DeleteCategory(int categoryId);
        Task CreateColor(CreateColorDto newColor);
        Task UpdateColor(int colorId, UpdateColorDto newColor);
        Task DeleteColor(int colorId);
        Task<bool> SaveChangesAsync();

    }
}
