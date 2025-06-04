namespace Orama_API.Model.DTO
{
    public class UpdateSubscriptionDTO
    {
        public string? SubscriptionPlan { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? MaxUsers { get; set; }
        public int? MaxStorage { get; set; } // in MB/GB depending on your app
    }
}
