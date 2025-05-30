using Microsoft.AspNetCore.Mvc;
using Orama_API.Data;
using Orama_API.Model.Domain;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetTokenController : ControllerBase
    {
        private readonly UserDbContext _context;

        public PasswordResetTokenController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PasswordResetToken token)
        {
            token.CreatedAt = DateTime.UtcNow;
            _context.PasswordResetTokens.Add(token);
            await _context.SaveChangesAsync();
            return Ok(token);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTokensForUser(Guid userId)
        {
            var tokens = await _context.PasswordResetTokens
                                       .Where(t => t.UserId == userId)
                                       .ToListAsync();
            return Ok(tokens);
        }

        [HttpPut("{id}/use")]
        public async Task<IActionResult> MarkUsed(Guid id)
        {
            var token = await _context.PasswordResetTokens.FindAsync(id);
            if (token == null) return NotFound();

            token.IsUsed = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
