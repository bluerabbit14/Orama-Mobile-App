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
            Routing.RegisterRoute(nameof(TermconditionPage), typeof(TermconditionPage));
        }
        private void OnLogoutClicked(object sender, EventArgs e)
        {  
            Preferences.Clear();  //Will Clear all the past locally saved Credential
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
        private void ThemeButton_Clicked(object sender, EventArgs e)
        {
            var currentTheme = Application.Current.UserAppTheme;
            var newTheme = currentTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;

            Application.Current.UserAppTheme = newTheme;
            Preferences.Set("AppTheme", newTheme.ToString());

            // Optional: update icon/text
            var button = sender as Button;
            button.Text = newTheme == AppTheme.Dark ? "🌙" : "☀️";
        }
    }
}
