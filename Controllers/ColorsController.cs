using AutoMapper;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    private readonly IFabricInfoRepository _fabricInfoRepository;
    private readonly ILogger<ColorsController> _logger; 
    private readonly IMapper _mapper;
    public ColorsController(IFabricInfoRepository fabricInfoRepository, ILogger<ColorsController> logger, IMapper mapper)
    {
        _fabricInfoRepository = fabricInfoRepository ?? throw new ArgumentNullException(nameof(fabricInfoRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    // GET: api/Color
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColorDto>>> GetColor(string? name, string? searchQuery)
    {
        var colors = await _fabricInfoRepository.GetColorsAsync(name, searchQuery);
        var result = _mapper.Map<IEnumerable<ColorDto>>(colors); // Map the list of colors to a list of ColorDto
        return Ok(result); 
    }

    // GET: api/Color/5
    [HttpGet("{colorid}")]
    public async Task<ActionResult<ColorDto>> GetColor(int colorid)
    {
        var color = await _fabricInfoRepository.GetColorAsync(colorid);
        if (color == null)
        {
            _logger.LogWarning("Color with id {id} not found.", colorid);
            return NotFound();
        }
        var result = _mapper.Map<ColorDto>(color); // Return the color as a ColorDto
        return Ok(result); 
    }

    // PUT: api/Color/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{colorid}")]
    public async Task<IActionResult> PutColor(int colorid, UpdateColorDto color)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Model state is invalid with updating color with id {id}", colorid);
            return BadRequest(ModelState);
        }

        var ColorToUpdate = await _fabricInfoRepository.GetColorAsync(colorid);

        if (ColorToUpdate == null)
        {
            _logger.LogWarning("Color with id {id} not found for update.", colorid);
            return NotFound();
        }

        _mapper.Map(color, ColorToUpdate); // Map the updated fields from the DTO to the existing color entity

        await _fabricInfoRepository.SaveChangesAsync();
        _logger.LogInformation("Color with id {id} updated successfully.", colorid);

        return NoContent();
    }

    // POST: api/Color
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ColorDto>> PostColor(CreateColorDto color)
    {

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Color does not meet all validation requirements");
            return BadRequest(ModelState);
        }
        var createdColor = _mapper.Map<Color>(color);
        await _fabricInfoRepository.CreateColor(createdColor);
        await _fabricInfoRepository.SaveChangesAsync();

        var newColor = _mapper.Map<ColorDto>(createdColor); // Map the created color to a ColorDto for the response

        return CreatedAtAction(nameof(GetColor), new { id = createdColor.Id }, newColor);
    }

    // DELETE: api/Color/5
    [HttpDelete("{colorid}")]
    public async Task<IActionResult> DeleteColor(int colorid)
    {
        var color = await _fabricInfoRepository.GetColorAsync(colorid);
        if (color == null)
        {
            _logger.LogWarning("Color with id {id} not found for deletion.", colorid);
            return NotFound();
        }

        _fabricInfoRepository.DeleteColor(color);
        await _fabricInfoRepository.SaveChangesAsync();
        _logger.LogInformation("Color with id {id} deleted successfully.", colorid);
        return NoContent();
    }

    private bool ColorExists(int? id)
    {
        return _fabricInfoRepository.GetColorsAsync().Result.Any(e => e.Id == id);
    }
}
