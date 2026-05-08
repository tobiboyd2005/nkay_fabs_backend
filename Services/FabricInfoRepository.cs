using nkay_fabs_backend.Entities;
using Microsoft.EntityFrameworkCore;

// endpoint logic
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

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Color?> GetColorAsync(int colorId)
        {
            return await _context.Colors.Where(c => c.Id == colorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Fabric?> GetFabricAsync(int fabricId)
        {
            return await _context.Fabrics.Where(f => f.Id == fabricId).FirstOrDefaultAsync();
        }       

        public async Task<IEnumerable<Fabric>> GetFabricsAsync()
        {
            return await _context.Fabrics.ToListAsync();
        }
    }
}
