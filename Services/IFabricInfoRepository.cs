using Microsoft.AspNetCore.JsonPatch;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Services
{
    public interface IFabricInfoRepository
    {
        // imported endpoint logic from /FabricInfoRepository
        Task<IEnumerable<Fabric>> GetFabricsAsync();
        Task<(IEnumerable<Fabric>, PaginationMetadata Metadata)> GetFabricsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Fabric?> GetFabricAsync(int fabricId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<(IEnumerable<Category>, PaginationMetadata Metadata)> GetCategoriesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Color>> GetColorsAsync();
        Task<(IEnumerable<Color>, PaginationMetadata Metadata)> GetColorsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Color?> GetColorAsync(int colorId);
        Task CreateFabric(Fabric newFabric);
        void DeleteFabric(Fabric fabric);
        Task CreateCategory(Category newCategory);
        void DeleteCategory(Category category);
        Task CreateColor(Color newColor);
        void DeleteColor(Color color);
        Task<bool> SaveChangesAsync();

    }
}
