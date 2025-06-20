using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Orama_API.Model.Domain
{
    public class UserPassword
    {
        [Key]public int PasswordId{get;set; } //primary key, auto-incremented
        public int? UserId { get; set; } 
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public DateTime? CreatedAt { get; set; } 
        public DateTime? LastUpdated { get; set; }

        public virtual UserProfile userProfile { get; set; }
    }
}
