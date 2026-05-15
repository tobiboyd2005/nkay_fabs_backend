using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace nkay_fabs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepo;
        private readonly IOtpVerificationRepository _otpVerificationRepo;
        private readonly IEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IUserRepository userRepository,
            IEmailVerificationRepository emailVerificationRepo,
            IOtpVerificationRepository otpVerificationRepo,
            IEmailService emailService,
            IOtpService otpService,
            IConfiguration configuration,
            IMapper mapper,
            ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _emailVerificationRepo = emailVerificationRepo;
            _otpVerificationRepo = otpVerificationRepo;
            _emailService = emailService;
            _otpService = otpService;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }


        // Register User
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userRepository.GetUserByUsernameAsync(request.Username) != null)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                return BadRequest(ModelState);
            }

            if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(request);
            user.PasswordHash = HashPassword(request.Password);

            await _userRepository.CreateUser(user);

            await _userRepository.SaveChangesAsync();

            var verificationToken = Guid.NewGuid().ToString();
            var emailVerification = new EmailVerification
            {
                UserId = user.Id,
                Token = verificationToken,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };

            await _emailVerificationRepo.Verification(emailVerification);
            await _emailVerificationRepo.SaveChangesAsync(); // ← save FIRST

            await _emailService.SendVerificationEmailAsync(user.Email, user.Username, verificationToken);

            var token = GenerateJwtToken(user);

            var response = new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };

            return CreatedAtAction(nameof(GetCurrentUser), new { token }, response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserByUsernameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userRepository.GetUserByEmailAsync(request.UsernameOrEmail);

            if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username/email or password.");
            }

            if (!user.IsActive)
                return Unauthorized("Account is deactivated.");

            var token = GenerateJwtToken(user);

            var response = new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };

            return Ok(response);
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequestDto request)
        {
            var verification = await _emailVerificationRepo.GetByTokenAsync(request.Token);
            if (verification == null)
                return BadRequest("Invalid or expired verification token.");

            var user = await _userRepository.GetUserByIdAsync(verification.UserId);
            if (user == null)
                return NotFound("User not found.");

            user.IsEmailVerified = true;
            verification.IsUsed = true;
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Email verified successfully." });
        }

        [HttpPost("resend-email-verification")]
        public async Task<IActionResult> ResendEmailVerification([FromBody] ForgotPasswordRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return Ok("If the email exists, a verification link will be sent.");

            if (user.IsEmailVerified)
                return BadRequest("Email is already verified.");

            var verificationToken = Guid.NewGuid().ToString();
            var emailVerification = new EmailVerification
            {
                UserId = user.Id,
                Token = verificationToken,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
            await _emailVerificationRepo.Verification(emailVerification);

            await _emailService.SendVerificationEmailAsync(user.Email, user.Username, verificationToken);

            return Ok(new { message = "Verification email sent." });
        }

        [HttpPost("generate-otp")]
        public async Task<ActionResult<AuthResponseDto>> GenerateOtp([FromBody] ForgotPasswordRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return BadRequest("User not found.");

            if (!user.IsActive)
                return Unauthorized("Account is deactivated.");

            var otpCode = _otpService.GenerateOtp();
            var otpVerification = new OtpVerification
            {
                UserId = user.Id,
                OtpCode = otpCode,
                ExpiresAt = DateTime.UtcNow.AddMinutes(10)
            };
            await _otpVerificationRepo.CreateAsync(otpVerification);

            await _otpService.SendOtpAsync(user.Email, otpCode);

            _logger.LogInformation("OTP generated for user {UserId}: {Otp}", user.Id, otpCode);

            return Ok(new { message = "OTP sent to your email." });
        }

        [HttpPost("verify-otp")]
        public async Task<ActionResult<AuthResponseDto>> VerifyOtp([FromBody] VerifyOtpRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return BadRequest("User not found.");

            var otpVerification = await _otpVerificationRepo.GetValidOtpAsync(user.Id, request.OtpCode);
            if (otpVerification == null)
                return BadRequest("Invalid or expired OTP.");

            otpVerification.IsUsed = true;
            await _userRepository.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            var response = new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };

            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return Ok("If the email exists, a password reset link will be sent.");

            var resetToken = Guid.NewGuid().ToString();
            var emailVerification = new EmailVerification
            {
                UserId = user.Id,
                Token = resetToken,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };
            await _emailVerificationRepo.Verification(emailVerification);

            await _emailService.SendPasswordResetEmailAsync(user.Email, user.Username, resetToken);

            return Ok(new { message = "Password reset email sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
        {
            var verification = await _emailVerificationRepo.GetByTokenAsync(request.Token);
            if (verification == null)
                return BadRequest("Invalid or expired reset token.");

            var user = await _userRepository.GetUserByIdAsync(verification.UserId);
            if (user == null)
                return NotFound("User not found.");

            user.PasswordHash = HashPassword(request.NewPassword);
            verification.IsUsed = true;
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Password reset successfully." });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            if (!VerifyPassword(request.CurrentPassword, user.PasswordHash))
                return BadRequest("Current password is incorrect.");

            user.PasswordHash = HashPassword(request.NewPassword);
            await _userRepository.SaveChangesAsync();

            return Ok(new { message = "Password changed successfully." });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            return Ok(_mapper.Map<UserDto>(user));
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("given_name", user.FirstName ?? ""),
                new Claim("family_name", user.LastName ?? "")
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}