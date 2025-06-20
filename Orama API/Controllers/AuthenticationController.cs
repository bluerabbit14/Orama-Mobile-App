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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(SignUpRequestDTO dto)
        {
            // 1. Basic validation
            if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.Phone))
                return BadRequest("Either email or phone is required.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Password is required.");

            // 2. Check if user exists
            var existingUser = await _context.UserProfilies.FirstOrDefaultAsync(u =>
                (!string.IsNullOrEmpty(dto.Email) && u.Email == dto.Email) ||
                (!string.IsNullOrEmpty(dto.Phone) && u.Phone == dto.Phone));

            if (existingUser != null)
            {
                var conflictMessage = (existingUser.Email == dto.Email && !string.IsNullOrEmpty(dto.Email))
                    ? "Email is already registered."
                    : "Phone is already registered.";
                return Conflict(new { Message = conflictMessage });
            }

            // 3. Create new user
            var newUser = new UserProfile
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                RememberMe = false, // explicitly false for clarity
                IsActive = true
            };

            await _context.UserProfilies.AddAsync(newUser);
            await _context.SaveChangesAsync(); // Save here to get newUser.UserId for FK

            // 4. Create password record
            var salt = PasswordHelper.GenerateSalt(); // assume this exists
            var hashedPassword = PasswordHelper.HashPassword(dto.Password, salt);

            var newUserPassword = new UserPassword
            {
                UserId = newUser.UserId, // foreign key
                PasswordHash = hashedPassword,
                Salt = salt,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            await _context.UserPasswords.AddAsync(newUserPassword);
            await _context.SaveChangesAsync();

            // ✅ Do NOT add newUser again — it was already saved

            return Ok(new
            {
                Message = "User registered successfully.",
                UserId = newUser.UserId
            });
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Credentials) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Email/Phone and Password are required.");

            var user = await _context.UserProfilies
            .FirstOrDefaultAsync(u => u.Email == dto.Credentials || u.Phone == dto.Credentials);

            if (user == null) return Unauthorized("Invalid credentials.");

            var userPassword = await _context.UserPasswords.FirstOrDefaultAsync(p => p.UserId == user.UserId);
            if (userPassword == null) return Unauthorized("Invalid credentials.");


            var hashedPassword = PasswordHelper.HashPassword(dto.Password, userPassword.Salt);

            if (hashedPassword != userPassword.PasswordHash)
                return Unauthorized("Invalid credentials.");

            //Update 'Remember me', 'LastLogin'
            user.RememberMe = dto.RememberMe;
            user.LastLogin = dto.LastLogin;

            return Ok(user);
        }

        [HttpPost("CredentialExist")]
        public async Task<IActionResult> ForgotPassword(CredentialExistDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Credentials))
                return BadRequest("Email or Phone is required.");
            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.Email == dto.Credentials || u.Phone == dto.Credentials);
            if (user == null)
                return NotFound("User not found.");
            return Ok("User Exist");
        }
    }
}
