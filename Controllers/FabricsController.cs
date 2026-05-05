using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Helpers;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Models.Entities;
using nkay_fabs_backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricsController : ControllerBase
    {

        private readonly FabricsDbContext _context;
        private ILogger<FabricsController> _logger;
        private FabricValidationService _validationService;

        public FabricsController(FabricsDbContext context, ILogger<FabricsController> logger, FabricValidationService validationService)
        {
            _context = context;
            _logger = logger;
            _validationService = validationService;
        }
        // GET: api/<FabricsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricDto>>> GetFabrics()
        {
            var fabrics = await _context.Fabrics
                .Include(f => f.Category)
                .Include(f => f.Color)
                .Select(f => new FabricDto
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        ImageUrl = f.ImageUrl,
                        PricePerYard = f.PricePerYard,
                        StockYards = f.StockYards,
                        IsInStock = f.IsInStock,
                        CategoryName = f.Category.Name,
                        ColorName = f.Color.Name,
                        ColorHex = f.Color.HexCode
                    })
                    .ToListAsync();

            return Ok(fabrics);
        }

        // GET api/<FabricsController>/5
        [HttpGet("{fabricId}")]
        public async Task<ActionResult<FabricDto>> GetFabric(int fabricId)
        {
            var fabric = await _context.Fabrics
                .Include(f => f.Category)
                .Include(f => f.Color)
                .Select(f => new FabricDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    ImageUrl = f.ImageUrl,
                    PricePerYard = f.PricePerYard,
                    StockYards = f.StockYards,
                    IsInStock = f.IsInStock,
                    CategoryName = f.Category.Name,
                    ColorName = f.Color.Name,
                    ColorHex = f.Color.HexCode
                })
                .FirstOrDefaultAsync(f => f.Id == fabricId);
            if (fabric == null)
            {
                _logger.LogWarning("Fabric of id {id} not found.", fabricId);
                return NotFound();
            }

            return Ok(fabric);
        }

        // POST api/<FabricsController>
        [HttpPost]
        public async Task<ActionResult> CreateFabric(CreateFabricDto NewFabric)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for fabric creation.");
                return BadRequest(ModelState);
            }

            if (!await _validationService.CategoryExistsAsync(NewFabric.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "The selected category does not exist.");
                _logger.LogWarning("Category Id does not exist");
                return BadRequest(ModelState);
            }

            if (!await _validationService.ColorExistsAsync(NewFabric.ColorId))
            {
                ModelState.AddModelError("ColorId", "The selected color does not exist.");
                _logger.LogWarning("Color Id does not exist");
                return BadRequest(ModelState);
            }


            var newFabric = new Fabric
            {
                Name = NewFabric.Name,
                Description = NewFabric.Description,
                PricePerYard = NewFabric.PricePerYard,
                ImageUrl = NewFabric.ImageUrl,
                StockYards = NewFabric.StockYards,
                CategoryId = NewFabric.CategoryId,
                ColorId = NewFabric.ColorId,
                CreatedAt = TimeHelper.NowWAT(),
                UpdatedAt = TimeHelper.NowWAT()
            };

            

            _context.Fabrics.Add(newFabric);
            await _context.SaveChangesAsync();

            //console log on successful creation
            _logger.LogInformation("Fabric {Name} created with ID {Id}.", newFabric.Name, newFabric.Id);

            // return 201 with location header pointing to the new resource
            return CreatedAtAction(nameof(GetFabric), new { fabricId = newFabric.Id }, newFabric);
        }

        // PATCH api/<FabricsController>/5
        [HttpPatch("{fabricId}")]
        public async Task<ActionResult> UpdateFabric(int fabricId, JsonPatchDocument<UpdateFabricDto> patchDoc)
        {
            var fabric = await _context.Fabrics.FindAsync(fabricId);
            if (fabric == null)
            {
                _logger.LogWarning("Fabric of {id} not found for update.", fabricId);
                return NotFound();
            }

            var updateFabric = new UpdateFabricDto
            {
                Name = fabric.Name,
                Description = fabric.Description,
                ImageUrl = fabric.ImageUrl,
                PricePerYard = fabric.PricePerYard,
                StockYards = fabric.StockYards,
                CategoryId = fabric.CategoryId,
                ColorId = fabric.ColorId
            };

            patchDoc.ApplyTo(updateFabric, ModelState);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for fabric update.");
                return BadRequest(ModelState);
            }

            fabric.Name = updateFabric.Name;
            fabric.Description = updateFabric.Description;
            fabric.ImageUrl = updateFabric.ImageUrl;
            fabric.PricePerYard = updateFabric.PricePerYard;
            fabric.StockYards = updateFabric.StockYards;
            fabric.CategoryId = updateFabric.CategoryId;
            fabric.ColorId = updateFabric.ColorId;
            fabric.UpdatedAt = TimeHelper.NowWAT();
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<FabricsController>/5
        [HttpDelete("{fabricId}")]
        public async Task<ActionResult> DeleteFabric(int fabricId)
        {
            var fabric = await _context.Fabrics.FindAsync(fabricId);
            if (fabric == null)
            {
                _logger.LogWarning("Fabric of {id} not found for deletion.", fabricId);
                return NotFound();
            }
            _context.Fabrics.Remove(fabric);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
