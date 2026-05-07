using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    private readonly FabricsDbContext _context;
    private readonly ILogger<ColorsController> _logger; 
    public ColorsController(FabricsDbContext context, ILogger<ColorsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/Color
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColorDto>>> GetColor()
    {
        _logger.LogInformation("Fetching all colors.");
        var colors = await _context.Colors.ToListAsync();

        var colorDtos = colors.Select(c => new ColorDto
        {
            Id = c.Id,
            Name = c.Name,
            HexCode = c.HexCode 
        });

        return Ok(colorDtos);
    }

    // GET: api/Color/5
    [HttpGet("{colorid}")]
    public async Task<ActionResult<ColorDto>> GetColor(int colorid)
    {
        var color = await _context.Colors.FindAsync(colorid);

        if (color == null)
        {
            _logger.LogWarning("Color with id of {id} not found.", colorid);
            return NotFound();
        }

        var colorDto = new ColorDto
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode
        };

        return Ok(colorDto);
    }

    // PUT: api/Color/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{colorid}")]
    public async Task<IActionResult> PutColor(int? colorid, UpdateColorDto color)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Model state is invalid with updating color with id {id}", colorid);
            return BadRequest(ModelState);
        }

        var ColorToUpdate = await _context.Colors.FindAsync(colorid);

        if (ColorToUpdate == null)
        {
            _logger.LogWarning("Color with id {id} not found for update.", colorid);
            return NotFound();
        }

        ColorToUpdate.Name = color.Name;
        ColorToUpdate.HexCode = color.HexCode;

        await _context.SaveChangesAsync();
        _logger.LogInformation("Color with id {id} updated successfully.", colorid);

        return NoContent();
    }

    // POST: api/Color
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult> PostColor(CreateColorDto color)
    {

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Color does not meet all validation requirements");
            return BadRequest(ModelState);
        }

        var newColor = new Color(color.Name)
        {
            HexCode = color.HexCode
        };

        await _context.Colors.AddAsync(newColor);
        await _context.SaveChangesAsync();
        _logger.LogInformation("The color {name} has been added successfully.", newColor.Name);

        return CreatedAtAction("GetColor", new { id = newColor.Id }, newColor);
    }

    // DELETE: api/Color/5
    [HttpDelete("{colorid}")]
    public async Task<IActionResult> DeleteColor(int colorid)
    {
        var color = await _context.Colors.FindAsync(colorid);
        if (color == null)
        {
            _logger.LogWarning("Color with id {id} not found for deletion.", colorid);
            return NotFound();
        }

        _context.Colors.Remove(color);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Color with id {id} deleted successfully.", colorid);
        return NoContent();
    }

    private bool ColorExists(int? id)
    {
        return _context.Colors.Any(e => e.Id == id);
    }
}
