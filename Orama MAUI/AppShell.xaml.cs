using Orama_MAUI.Pages;

namespace Orama_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(ContactUsPage), typeof(ContactUsPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(FeedbackPage), typeof(FeedbackPage));
            Routing.RegisterRoute(nameof(PrivacyPolicyPage), typeof(PrivacyPolicyPage));
            Routing.RegisterRoute(nameof(TermsConditionPage), typeof(TermsConditionPage));
            Routing.RegisterRoute(nameof(FAQPage), typeof(FAQPage));
            Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
        }
    }
}
