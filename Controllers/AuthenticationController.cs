using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nkay_fabs_backend.Services;

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthenticationController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                var token = _jwtService.GenerateToken(username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
