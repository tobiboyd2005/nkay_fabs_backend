using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Helpers;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricsController : ControllerBase
    {

        private readonly IFabricInfoRepository _fabricInfoRepository;
        private readonly ILogger<FabricsController> _logger;
        private readonly FabricValidationService _validationService;
        private readonly IMapper _mapper;

        public FabricsController(IFabricInfoRepository fabricInfoRepository, ILogger<FabricsController> logger, FabricValidationService validationService, IMapper mapper)
        {
            _fabricInfoRepository = fabricInfoRepository ?? throw new ArgumentNullException(nameof(fabricInfoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<FabricsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricDto>>> GetFabrics()
        {
            try
            {
                var fabrics = await _fabricInfoRepository.GetFabricsAsync();
                var result = _mapper.Map<IEnumerable<FabricDto>>(fabrics); // Map the list of Fabric entities to a list of FabricDto objects
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while retrieving fabrics.");
                return StatusCode(500, "An error occurred while processing your request.");
            }   
        }

        // GET api/<FabricsController>/5
        [HttpGet("{fabricId}")]
        public async Task<ActionResult<FabricDto>> GetFabric(int fabricId)
        {
            var fabric = await _fabricInfoRepository.GetFabricAsync(fabricId);
            if (fabric == null)
            {
                _logger.LogWarning("Fabric of id {id} not found.", fabricId);
                return NotFound();
            }

            var result = _mapper.Map<FabricDto>(fabric); // Map the Fabric entity to a FabricDto object
            return Ok(result);
        }

        // POST api/<FabricsController>
        [HttpPost]
        public async Task<ActionResult<FabricDto>> CreateFabric(CreateFabricDto NewFabric)
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

            var createdFabric = _mapper.Map<Fabric>(NewFabric);

            await _fabricInfoRepository.CreateFabric(createdFabric);

            await _fabricInfoRepository.SaveChangesAsync();

            var fabricWithDetails = await _fabricInfoRepository.GetFabricAsync(createdFabric.Id);

            var response = _mapper.Map<FabricDto>(fabricWithDetails);

            return CreatedAtAction(nameof(GetFabric),
                new
                {
                    fabricId = createdFabric.Id
                },
                response);
        }

        // PATCH api/<FabricsController>/5
        [HttpPatch("{fabricId}")]
        public async Task<ActionResult> UpdateFabric(int fabricId, UpdateFabricDto patchDto)
        {
            try
            {
                var fabric = await _fabricInfoRepository.GetFabricAsync(fabricId);
                if (fabric == null)
                {
                    _logger.LogWarning("Fabric of {id} not found for update.", fabricId);
                    return NotFound();
                }

                _mapper.Map(patchDto, fabric);

                await _fabricInfoRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while updating fabric {id}.", fabricId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE api/<FabricsController>/5
        [HttpDelete("{fabricId}")]
        public async Task<ActionResult> DeleteFabric(int fabricId)
        {
            var fabric = await _fabricInfoRepository.GetFabricAsync(fabricId);
            if (fabric == null)
            {
                _logger.LogWarning("Fabric of {id} not found for deletion.", fabricId);
                return NotFound();
            }
            _fabricInfoRepository.DeleteFabric(fabric);
            await _fabricInfoRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
