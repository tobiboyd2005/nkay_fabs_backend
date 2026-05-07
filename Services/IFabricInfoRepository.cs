using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface IFabricInfoRepository
    {
        Task<IEnumerable<Fabric>> GetFabricsAsync();
        Task<Fabric?> GetFabricAsync(int fabricId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Color>> GetColorsAsync();
        Task<Color?> GetColorAsync(int colorId);
    }
}
