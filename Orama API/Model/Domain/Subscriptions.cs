using System.Text.Json.Serialization;

namespace Orama_API.Model.Domain
{
    public class Subscriptions
    {
        public int SubscriptionId { get; set; }
        public string PlanName { get; set; }
        public string? Description { get; set; } = null;
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; } = DateTime.UtcNow;
        public bool? IsActive { get; set; } = true;
        public int? ActiveUsers { get; set; } = 0; // Default active users  
        public int? MaxUsers { get; set; } = 10; // Default max users
        public int? MaxStorage { get; set; } = 1000; // in MB

        [JsonIgnore]public ICollection<Users>? Users { get; set; } = new List<Users>(); // A subscription can have multiple users
    }
}
