using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Models
{
    internal class SignUpRequest
    {
        public string? Name { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? ConfirmPassword { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? DeviceId { get; set; }

        public string? IPAddress { get; set; }

        public string? Location { get; set; }

        public DateTime SignupTime { get; set; } = DateTime.UtcNow;
        public bool AcceptTermsAndConditions { get; set; } = false;
    }
}
