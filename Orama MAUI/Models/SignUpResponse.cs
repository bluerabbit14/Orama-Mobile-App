using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Models
{
    internal class SignUpResponse
    {
        public string UserId { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public DateTime SignupTime { get; set; }

        public string? WelcomeMessage { get; set; }
    }
}
