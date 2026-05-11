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

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await GetCategoriesAsync();
            }

            return await _context.Categories
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
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

        public async Task<IEnumerable<Fabric>> GetFabricsAsync(string? name, string? searchQuery)
        {
            // No filters provided - return everything
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(searchQuery))
            {
                return await GetFabricsAsync();
            }

            // Build query without executing it yet
            var collection = _context.Fabrics as IQueryable<Fabric>;

            // Exact name match
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            // Partial match across Name and Description
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery) ||
                    (a.Description != null && a.Description.Contains(searchQuery)));
            }

            // Execute query, sort by name and return
            return await collection.OrderBy(c => c.Name).ToListAsync();
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

        public async Task CreateCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
        }



        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task CreateColor(Color newColor)
        {
            _context.Colors.Add(newColor);
        }

        public void DeleteColor(Color color)
        {
            _context.Colors.Remove(color);
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _context.Colors.ToListAsync();
        }
        public async Task<IEnumerable<Color>> GetColorsAsync(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await GetColorsAsync();
            }

            return await _context.Colors
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }


        public async Task<Color?> GetColorAsync(int colorId)
        {
            return await _context.Colors.Where(c => c.Id == colorId).FirstOrDefaultAsync();
        }

        public void DeleteFabric(Fabric fabric)
        {
            _context.Fabrics.Remove(fabric);
        }
    }
} 
