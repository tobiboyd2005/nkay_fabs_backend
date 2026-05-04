// Services/FabricValidationService.cs
using Microsoft.EntityFrameworkCore;

namespace nkay_fabs_backend.Services
{
    public class FabricValidationService
    {
        private readonly FabricsDbContext _context;

        public FabricValidationService(FabricsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsAsync(int categoryId) =>
            await _context.Categories.AnyAsync(c => c.Id == categoryId);

        public async Task<bool> ColorExistsAsync(int colorId) =>
            await _context.Colors.AnyAsync(c => c.Id == colorId);
    }
}