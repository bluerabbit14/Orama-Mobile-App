
using Orama_MAUI.Pages;

namespace Orama_MAUI.Services
{
    internal class CommonFunctionService
    {
        public static void ChangeTheme()
        {
            var currentTheme = Application.Current.UserAppTheme;
            var newTheme = currentTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;

            Application.Current.UserAppTheme = newTheme;
            string newtheme = newTheme.ToString();
            UserPreferencesService.Save("AppTheme", newtheme);//Saving Apptheme 
        }
        public static void PerformLogout()
        {
            UserPreferencesService.ClearAllExcept(new Dictionary<string, Type>
        {
           { "AppTheme", typeof(string) }
        });
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
