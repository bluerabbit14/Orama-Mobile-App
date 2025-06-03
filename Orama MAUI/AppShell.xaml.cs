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
            Routing.RegisterRoute(nameof(FeedbackPage), typeof(FeedbackPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
            Routing.RegisterRoute(nameof(PrivacypolicyPage), typeof(PrivacypolicyPage));
            Routing.RegisterRoute(nameof(AboutusPage), typeof(AboutusPage));
        }
    }
}
