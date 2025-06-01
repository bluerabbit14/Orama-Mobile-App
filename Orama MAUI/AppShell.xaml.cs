using Orama_MAUI.Pages;

namespace Orama_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
            Routing.RegisterRoute(nameof(ForgotpasswordPage), typeof(ForgotpasswordPage));
            Routing.RegisterRoute(nameof(ContactusPage), typeof(ContactusPage));
        }
    }
}
