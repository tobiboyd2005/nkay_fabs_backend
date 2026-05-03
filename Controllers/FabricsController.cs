using Microsoft.AspNetCore.Mvc;
using nkay_fabs_backend.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricsController : ControllerBase
    {
        // GET: api/<FabricsController>
        [HttpGet]
        public IEnumerable<FabricDto> GetFabrics()
        {
            
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
