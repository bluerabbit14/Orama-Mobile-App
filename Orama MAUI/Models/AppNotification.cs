using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Models
{
    internal class AppNotification
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string? ActionUrl { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
