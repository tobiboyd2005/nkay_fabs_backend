// --- Imports ---
using Microsoft.AspNetCore.Http;       // Provides HTTP context types (StatusCodes, HttpRequest, etc.)
using Microsoft.AspNetCore.Mvc;        // Provides ControllerBase, ActionResult, [HttpPost], [ApiController], etc.
using Microsoft.IdentityModel.Tokens;  // Provides SymmetricSecurityKey, SigningCredentials, SecurityAlgorithms
using nkay_fabs_backend.Services;      // Brings in your custom JwtService class
using System.IdentityModel.Tokens.Jwt; // Provides JwtSecurityToken and JwtSecurityTokenHandler
using System.Security.Claims;          // Provides Claim and List<Claim> for JWT payload data

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]  // All endpoints in this controller are prefixed with /api/Authentication
    [ApiController]              // Enables automatic model validation, binding, and error responses
    public class AuthenticationController : ControllerBase  // Inherits HTTP helper methods like Ok(), Unauthorized()
    {
        // Private fields — only accessible within this controller
        private readonly JwtService _jwtService;        // Your custom service for JWT operations
        private readonly IConfiguration _configuration; // Gives access to appsettings.json values

        // Constructor — ASP.NET's DI container automatically injects these when the controller is created
        public AuthenticationController(JwtService jwtService, IConfiguration configuration)
        {
            _jwtService = jwtService;
            // If configuration is null, crash immediately with a clear error instead of failing silently later
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // Private inner class — only usable inside AuthenticationController
        // Represents the logged-in user's data after credentials are validated
        private class InfoUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }

            // Constructor to set all properties at once when creating an InfoUser object
            public InfoUser(int userId, string userName, string firstName, string lastName, string email, string address)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Address = address;
            }
        }

        // Public class — represents the JSON body ASP.NET expects from the POST /login request
        public class LoginRequest
        {
            public string? Username { get; set; } // Nullable — won't crash if client omits it
            public string? Password { get; set; } // Nullable — same reason
        }

        [HttpPost("login")] // This method handles POST requests to /api/Authentication/login
        public ActionResult<string> Login(LoginRequest request) // Returns either a JWT string or an error response
        {
            // Call the validation method below — passes in the username and password from the request body
            var user = ValidateUserCredentials(request.Username, request.Password);

            // If no user was found/validated, stop here and return HTTP 401 Unauthorized
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Read the secret key from appsettings.json and decode it from Base64 into raw bytes
            // This key is used to sign the JWT so it can't be tampered with
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));

            // Wrap the key with the algorithm that will be used to sign the token (HMAC-SHA256)
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Build the list of claims — these are the pieces of user data embedded inside the JWT payload
            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()),  // "sub" = subject, standard JWT field for user ID
                new Claim("given_name", user.FirstName),   // User's first name
                new Claim("family_name", user.LastName),   // User's last name
                new Claim("address", user.Address)         // User's address
            };

            // Construct the JWT object with all its parts:
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],    // Who issued the token (e.g. "nkay-fabs-api")
                _configuration["Authentication:Audience"],  // Who the token is intended for (e.g. "nkay-fabs-client")
                claimsForToken,                             // The payload data built above
                DateTime.UtcNow,                            // Token is valid starting right now
                DateTime.UtcNow.AddHours(1),                // Token expires in 1 hour
                signingCredentials);                        // Sign it with the secret key + algorithm

            // Serialize the JwtSecurityToken object into the actual JWT string (3 Base64 parts separated by dots)
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            // Return HTTP 200 OK with the JWT string as the response body
            return Ok(tokenToReturn);
        }

        // Called by Login() to verify the credentials — returns null if invalid, InfoUser if valid
        private InfoUser? ValidateUserCredentials(string? username, string? password)
        {
            // TODO: Replace with a real database lookup
            // Currently always returns a hardcoded user regardless of what username/password was passed in
            return new InfoUser(
                1,                                               // Hardcoded user ID
                username ?? "",                                  // Uses provided username, or empty string if null
                "John",                                          // Hardcoded first name
                "Doe",                                           // Hardcoded last name
                "john.doe@example.com",                          // Hardcoded email
                "3 Chris Phillips Street, New York, NY 10001"    // Hardcoded address
            );
        }
    }
}