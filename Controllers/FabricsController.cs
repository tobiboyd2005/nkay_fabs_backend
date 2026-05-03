using Microsoft.AspNetCore.Mvc;
using nkay_fabs_backend.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricsController : ControllerBase
    {

        private readonly FabricsDbContext _context;
        private ILogger<FabricsController> _logger;

        public FabricsController(FabricsDbContext context, ILogger<FabricsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: api/<FabricsController>
        [HttpGet]
        public ActionResult<IEnumerable<FabricDto>> GetFabrics()
        {
            var Fabrics = _context.Fabrics;
            if (Fabrics == null) 
            {
                _logger.LogWarning("No fabrics found.");
                return NotFound();
            }

            return Ok(Fabrics);
        }

        // GET api/<FabricsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FabricsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FabricsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FabricsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
