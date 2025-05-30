using Microsoft.AspNetCore.Mvc;
using Orama_API.Data;
using Orama_API.Model.Domain;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserLoginController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogins() => Ok(await _context.UserLogins.Include(l => l.User).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(UserLogin login)
        {
            login.LoginTime = DateTime.UtcNow;
            _context.UserLogins.Add(login);
            await _context.SaveChangesAsync();
            return Ok(login);
        }
    }

}
