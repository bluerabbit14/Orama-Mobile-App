using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama_MAUI.Models
{
    internal class AppSetting
    {
        public string Theme { get; set; } = "Light";
        public string Language { get; set; } = "en";
        public bool NotificationsEnabled { get; set; } = true;
    }
}
