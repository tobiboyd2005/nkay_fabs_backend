using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;


[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IFabricInfoRepository _fabricInfoRepository;
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMapper _mapper;
    const int maxPageSize = 20;
    public CategoriesController(IFabricInfoRepository fabricInfoRepository, ILogger<CategoriesController> logger, IMapper mapper)
    {
        _fabricInfoRepository = fabricInfoRepository ?? throw new ArgumentNullException(nameof(fabricInfoRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    // GET: api/Category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }
            var categories = await _fabricInfoRepository.GetCategoriesAsync(name, searchQuery, pageNumber, pageSize);
            var results = _mapper.Map<IEnumerable<CategoryDto>>(categories); // Use AutoMapper to map categories to CategoryDtos
            return Ok(results);
        }
        catch(Exception ex)
        {
            _logger.LogCritical("There is a problem with the server {ex}", ex);
            return StatusCode(500, "There is a problem with the server");
        }
    }

    // GET: api/Category/5
    [HttpGet("{categoryid}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int categoryid)
    {
        var category = await _fabricInfoRepository.GetCategoryAsync(categoryid);

        if (category == null)
        {
            _logger.LogWarning("Category with id {id} not found.", categoryid);
            return NotFound();
        }

        var result = _mapper.Map<CategoryDto>(category); // Use AutoMapper to map the category to a CategoryDto


        return Ok(result);
    }

    // PUT: api/Category/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{categoryid}")]
    public async Task<IActionResult> PutCategory(int categoryid, UpdateCategoryDto category)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for category update.");
            return BadRequest(ModelState);
        }

        var categoryToUpdate = await _fabricInfoRepository.GetCategoryAsync(categoryid);

        if (categoryToUpdate == null)
        {
            _logger.LogWarning("Category of id {id} not found.", categoryid);
            return NotFound();
        }

        _mapper.Map(category, categoryToUpdate); // Map the updated fields from the DTO to the existing category entity
        await _fabricInfoRepository.SaveChangesAsync();
        _logger.LogInformation("Category with id {id} updated successfully.", categoryid);

        return NoContent();
    }

    // POST: api/Category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult> PostCategory(CreateCategoryDto category)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for category creation.");
            return BadRequest(ModelState);
        }

        var newCategory = _mapper.Map<Category>(category); // Map the CreateCategoryDto to a Category entity

        await _fabricInfoRepository.CreateCategory(newCategory);
        await _fabricInfoRepository.SaveChangesAsync();
        _logger.LogInformation("Category with id {id} created successfully.", newCategory.Id);

        var categoryDto = _mapper.Map<CategoryDto>(newCategory); // Map the created category to a CategoryDto for the response

        return CreatedAtAction(nameof(GetCategory), new { id = newCategory.Id }, categoryDto);
    }

    // DELETE: api/Category/5
    [HttpDelete("{categoryid}")]
    public async Task<IActionResult> DeleteCategory(int categoryid)
    {
        var category = await _fabricInfoRepository.GetCategoryAsync(categoryid);
        if (category == null)
        {
            _logger.LogWarning("Category with id {id} is not available for deletion", categoryid);
            return NotFound();
        }

        _fabricInfoRepository.DeleteCategory(category);
        await _fabricInfoRepository.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int? id)
    {
        return _fabricInfoRepository.GetCategoriesAsync().Result.Any(e => e.Id == id);
    }
}
