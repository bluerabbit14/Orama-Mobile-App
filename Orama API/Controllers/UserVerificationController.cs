using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Model.Domain;
using Orama_API.Model.DTO.UserVerificationDTO;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserVerificationController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserVerificationController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVerifications verification)
        {
            verification.CreatedAt = DateTime.UtcNow;
            _context.UserVerifications.Add(verification);
            await _context.SaveChangesAsync();
            return Ok(verification);
        }

        [HttpPut("{id}/use")]
        public async Task<IActionResult> MarkUsed(Guid id)
        {
            var record = await _context.UserVerifications.FindAsync(id);
            if (record == null) return NotFound();

            record.IsUsed = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
