using Orama_MAUI.Pages;

namespace Orama_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //MainPage = new LoginPage();
        }
    }
}
