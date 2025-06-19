using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Models
{
    internal class LoginReponse
    {
        public string Token { get; set; } = string.Empty;         // JWT access token

        public string RefreshToken { get; set; } = string.Empty;  // For session refresh

        public DateTime ExpiresAt { get; set; }                   // Token expiration time

        public string UserId { get; set; } = string.Empty;        // Useful for client-side checks

        public string Role { get; set; } = "User";                // Role-based access control

        public DateTime LoginTime { get; set; }                   // Server-confirmed login time

        public string? Location { get; set; }
    }
}
