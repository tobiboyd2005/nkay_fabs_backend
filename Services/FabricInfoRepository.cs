using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public class FabricInfoRepository : IFabricInfoRepository
    {
        private readonly FabricsDbContext _context;

        public FabricInfoRepository(FabricsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Task<Category?> GetCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Color?> GetColorAsync(int colorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Color>> GetColorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Fabric?> GetFabricAsync(int fabricId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fabric>> GetFabricsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
