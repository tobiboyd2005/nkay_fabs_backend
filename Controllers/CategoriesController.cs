using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;


[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly FabricsDbContext _context;
    private readonly ILogger<CategoriesController> _logger;
    public CategoriesController(FabricsDbContext context, ILogger<CategoriesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/Category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory()
    {
        var categories = await _context.Categories.ToListAsync();
        var categoryDtos = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        });
        return Ok(categoryDtos);
    }

    // GET: api/Category/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            _logger.LogWarning("Category with id {id} not found.", id);
            return NotFound();
        }

        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return Ok(categoryDto);
    }

    // PUT: api/Category/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto category)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for category update.");
            return BadRequest(ModelState);
        }

        var categoryToUpdate = await _context.Categories.FindAsync(id);

        if (categoryToUpdate == null)
        {
            _logger.LogWarning("Category of id {id} not found.", id);
            return NotFound();
        }

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/Category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult> PostCategory(CreateCategoryDto category)
    {
        if(!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for category creation.");
            return BadRequest(ModelState);
        }

        var newCategory = new Category(category.Name)
        {
            Description = category.Description
        };

        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Category with id {id} created successfully.", newCategory.Id);

        return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
    }

    // DELETE: api/Category/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {id} is not available for deletion", id);
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int? id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
