using Orama_MAUI.Pages;
using Orama_MAUI.Services;

namespace Orama_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var Theme = UserPreferencesService.Get("AppTheme", "Unspecified");
            if (Enum.TryParse<AppTheme>(Theme, out var appTheme))
                Application.Current.UserAppTheme = appTheme;
            else
                Application.Current.UserAppTheme = AppTheme.Light;

            bool isLoggedIn = UserPreferencesService.Get("IsLoggedIn", false);
            MainPage = isLoggedIn
                ? new AppShell()
                : new NavigationPage(new LoginPage());
        }

    }
}
