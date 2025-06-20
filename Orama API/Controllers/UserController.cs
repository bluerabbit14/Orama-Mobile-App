using Microsoft.AspNetCore.Mvc;
using Orama_API.Data;
using Orama_API.Model.Domain;
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

    }
}
