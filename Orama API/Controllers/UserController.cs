using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Model.DTO;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet("Fetch")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.User
            .Include(u => u.Subscription)
            .Select(u => new UserResponseDTO
            {
                UserId = u.UserId,
                Email = u.Email,
                Phone = u.Phone,
                UserName = u.UserName,
                PasswordHash = u.PasswordHash,
                IsEmailVerified = u.IsEmailVerified,
                IsPhoneVerified = u.IsPhoneVerified,
                CreatedAt = u.CreatedAt,
                LastUpdated = u.LastUpdated,
                IsActive = u.IsActive,
                Role = u.Role,
                SubscriptionId = u.SubscriptionId,
                SubscriptionPlan = u.Subscription != null ? u.Subscription.PlanName : null
            })
            .ToListAsync();
            return Ok(users);
        }

        [HttpGet("FetchById/{id}")]
        public async Task<IActionResult> GetUserByID(Guid id)
        {
            var user = await _context.User
                .Where(u => u.UserId == id)
                .Select(u => new UserResponseDTO
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    Phone = u.Phone,
                    UserName = u.UserName,
                    PasswordHash = u.PasswordHash,
                    IsEmailVerified = u.IsEmailVerified,
                    IsPhoneVerified = u.IsPhoneVerified,
                    CreatedAt = u.CreatedAt,
                    LastUpdated = u.LastUpdated,
                    IsActive = u.IsActive,
                    Role = u.Role,
                    SubscriptionId = u.SubscriptionId,
                    SubscriptionPlan = u.Subscription != null ? u.Subscription.PlanName : null
                })
                .FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("FetchByIdentifier")]
        public async Task<IActionResult> GetUserByIdentifier([FromQuery] string identifier)
        {
            var user = await _context.User
                .Where(u => u.Email == identifier || u.Phone == identifier)
                .Select(u => new UserResponseDTO
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    Phone = u.Phone,
                    UserName = u.UserName,
                    PasswordHash = u.PasswordHash,
                    IsEmailVerified = u.IsEmailVerified,
                    IsPhoneVerified = u.IsPhoneVerified,
                    CreatedAt = u.CreatedAt,
                    LastUpdated = u.LastUpdated,
                    IsActive = u.IsActive,
                    Role = u.Role,
                    SubscriptionId = u.SubscriptionId,
                    SubscriptionPlan = u.Subscription != null ? u.Subscription.PlanName : null
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound("User not found.");
            return Ok(user);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO dto, Guid id)
        { 
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return NotFound("User not found.");

            // Only update fields if values are provided
            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Phone))
                user.Phone = dto.Phone;

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                user.UserName = dto.UserName;

            user.LastUpdated = DateTime.UtcNow;

            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "User updated successfully.",
                UserId = user.UserId
            });
        }

        [HttpPut("UpdatePassword/{credential}")]
        public async Task<IActionResult> UpdatePassword(PasswordUpdateDTO dto, string credential)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == credential || u.Phone == credential);

            if (user == null)
                return NotFound("User not found.");

            user.PasswordHash = dto.PasswordHash; // Consider hashing here
            user.LastUpdated = DateTime.UtcNow;

            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Password updated successfully.",
                UserId = user.UserId
            });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return NotFound("User not found.");
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "User deleted successfully.",
                UserId = id
            });
        }
    }
}
