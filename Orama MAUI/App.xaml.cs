using Orama_MAUI.Pages;

namespace Orama_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

            if (isLoggedIn)
            {
                MainPage = new AppShell(); // Go to main app
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage()); // Ask to log in
            }
        }
    }
}
