using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Model.Domain;
using Orama_API.Model.DTO;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly UserDbContext _context;

        public SubscriptionController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscriptions()
        {
            var subscriptions = await _context.Subscription
            .Select(s => new SubscriptionResponseDTO
            {
                SubscriptionId = s.SubscriptionId,
                SubscriptionPlan = s.SubscriptionPlan,
                Description = s.Description,
                Price = s.Price,
                CreatedAt = s.CreatedAt,
                LastUpdated = s.LastUpdated,
                IsActive = s.IsActive,
                ActiveUsers = s.ActiveUsers,
                MaxUsers = s.MaxUsers,
                MaxStorage = s.MaxUsers
            })
            .ToListAsync();
            return Ok(subscriptions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionByID(int id)
        {
            var subscription = await _context.Subscription
                .Where(s => s.SubscriptionId == id)
                .Select(s => new SubscriptionResponseDTO
                {
                    SubscriptionId = s.SubscriptionId,
                    SubscriptionPlan = s.SubscriptionPlan,
                    Description = s.Description,
                    Price = s.Price,
                    CreatedAt = s.CreatedAt,
                    LastUpdated = s.LastUpdated,
                    IsActive = s.IsActive,
                    ActiveUsers = s.ActiveUsers,
                    MaxUsers = s.MaxUsers,
                    MaxStorage = s.MaxStorage
                })
                .FirstOrDefaultAsync();

            if (subscription == null)
                return NotFound();
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterSubscriptionDTO dto)
        {
            var subscription = new Subscriptions
            {
                SubscriptionPlan = dto.SubscriptionPlan,
                Description = dto.Description,
                Price = (decimal)dto.Price,
                MaxUsers = dto.MaxUsers,
                MaxStorage = dto.MaxStorage
            };

            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubscriptions), new { id = subscription.SubscriptionId }, subscription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(int id, UpdateSubscriptionDTO dto)
        {
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
                return NotFound("Subscription not found.");

            var updatedFields = new List<string>();

            if (!string.IsNullOrWhiteSpace(dto.SubscriptionPlan) && dto.SubscriptionPlan != subscription.SubscriptionPlan)
            {
                subscription.SubscriptionPlan = dto.SubscriptionPlan;
                updatedFields.Add(nameof(dto.SubscriptionPlan));
            }

            if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description != subscription.Description)
            {
                subscription.Description = dto.Description;
                updatedFields.Add(nameof(dto.Description));
            }

            if (dto.Price.HasValue && dto.Price.Value != subscription.Price)
            {
                subscription.Price = dto.Price.Value;
                updatedFields.Add(nameof(dto.Price));
            }

            if (dto.MaxUsers.HasValue && dto.MaxUsers.Value != subscription.MaxUsers)
            {
                subscription.MaxUsers = dto.MaxUsers.Value;
                updatedFields.Add(nameof(dto.MaxUsers));
            }

            if (dto.MaxStorage.HasValue && dto.MaxStorage.Value != subscription.MaxStorage)
            {
                subscription.MaxStorage = dto.MaxStorage.Value;
                updatedFields.Add(nameof(dto.MaxStorage));
            }

            if (updatedFields.Count == 0)
            {
                return Ok(new
                {
                    Message = "No changes made.",
                    SubscriptionId = id
                });
            }

            subscription.LastUpdated = DateTime.UtcNow;
            _context.Subscription.Update(subscription);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Subscription updated successfully.",
                UpdatedFields = updatedFields,
                SubscriptionId = id
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
                return NotFound();
            _context.Subscription.Remove(subscription);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "Subscription deleted successfully.",
                SubscriptionId = id
            });
        }
        [HttpPut("{id}/Activate")]
        public async Task<IActionResult> ActivateSubscription(int id)
        {
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
                return NotFound();
            subscription.IsActive = true;
            subscription.LastUpdated = DateTime.UtcNow;

            _context.Subscription.Update(subscription);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "Subscription Activated successfully.",
                SubscriptionId = id
            });

        }
    }
}
