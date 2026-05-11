using nkay_fabs_backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using nkay_fabs_backend.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Build.Framework;
using AutoMapper;

// endpoint logic
namespace nkay_fabs_backend.Services
{
    public class FabricInfoRepository : IFabricInfoRepository
    {
        private readonly FabricsDbContext _context;
        private readonly IMapper _mapper;

        public FabricInfoRepository(FabricsDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            return await _context.Fabrics
                .Include(f => f.Category)
                .Include(f => f.Color)
                .Where(f => f.Id == fabricId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Fabric>> GetFabricsAsync()
        {
            return await _context.Fabrics
                .Include(f => f.Category)
                .Include(f => f.Color)
                .ToListAsync();
        }

        public async Task CreateFabric(Fabric newFabric)
        {
            _context.Fabrics.Add(newFabric);
        }

        public async Task DeleteFabric(int fabricId)
        {
            var fabricToDelete = await GetFabricAsync(fabricId);
            if (fabricToDelete != null)
            {
                _context.Fabrics.Remove(fabricToDelete);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        Task IFabricInfoRepository.PartialUpdateFabric(int fabricId, JsonPatchDocument<UpdateFabricDto> patchDoc)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.CreateCategory(CreateCategoryDto newCategory)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.UpdateCategory(int categoryId, UpdateCategoryDto newCategory)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.CreateColor(CreateColorDto newColor)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.UpdateColor(int colorId, UpdateColorDto newColor)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.DeleteColor(int colorId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> IFabricInfoRepository.GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Category?> IFabricInfoRepository.GetCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Color>> IFabricInfoRepository.GetColorsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Color?> IFabricInfoRepository.GetColorAsync(int colorId)
        {
            throw new NotImplementedException();
        }

        Task IFabricInfoRepository.DeleteFabric(int fabricId)
        {
            throw new NotImplementedException();
        }

        async Task<bool> IFabricInfoRepository.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
} 
