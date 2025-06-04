using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Model.Domain;
using Orama_API.Model.DTO;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserDbContext _context;

        public AuthenticationController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.Phone))
                return BadRequest("Either email or phone is required.");

            if (string.IsNullOrWhiteSpace(dto.PasswordHash))
                return BadRequest("Password is required.");

            // Check for existing user by email or phone
            var existingUser = await _context.User.FirstOrDefaultAsync(u =>
                (!string.IsNullOrEmpty(dto.Email) && u.Email == dto.Email) ||
                (!string.IsNullOrEmpty(dto.Phone) && u.Phone == dto.Phone));

            if (existingUser != null)
            {
                var conflictMessage = (existingUser.Email == dto.Email && !string.IsNullOrEmpty(dto.Email))
                    ? "Email is already registered."
                    : "Phone is already registered.";

                return Conflict(new { Message = conflictMessage });
            }

            // Create and save new user
            var newUser = new Users
            {
                Email = dto.Email,
                Phone = dto.Phone,
                PasswordHash = dto.PasswordHash // Consider hashing before saving
            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "User registered successfully.",
                UserId = newUser.UserId
            });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Identifier) || string.IsNullOrWhiteSpace(dto.PasswordHash))
                return BadRequest("Email/Phone and Password are required.");
            var user = await _context.User
                .Include(u => u.Subscription)
                .FirstOrDefaultAsync(u =>
                    (u.Email == dto.Identifier || u.Phone == dto.Identifier) && u.PasswordHash == dto.PasswordHash);
            if (user == null)
                return Unauthorized("Invalid credentials.");
            return Ok(user);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EmailOrPhone))
                return BadRequest("Email or Phone is required.");
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Email == dto.EmailOrPhone || u.Phone == dto.EmailOrPhone);
            if (user == null)
                return NotFound("User not found.");
            return Ok(user);
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromBody] OTPVerifyDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EmailOrPhone) || string.IsNullOrWhiteSpace(dto.OtpCode))
                return BadRequest("Email/Phone and OtpCode are required.");

            var user = await _context.User
                .Include(u => u.Subscription)
                .FirstOrDefaultAsync(u =>
                    u.Email == dto.EmailOrPhone || u.Phone == dto.EmailOrPhone);
            //have config otpcode checker too table have no otp column config it just return true and just email/phone exist or not

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }
    }
}
