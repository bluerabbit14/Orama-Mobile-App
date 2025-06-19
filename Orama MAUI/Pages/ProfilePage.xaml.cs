using Orama_MAUI.Services;

namespace Orama_MAUI.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private void LogoutButton_Clicked(object sender, EventArgs e)
    {
        CommonFunctionService.PerformLogout();
    }
    private void Feedback_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new FeedbackPage());
    }

    private void Theme_Tapped(object sender, TappedEventArgs e)
    {
        CommonFunctionService.ChangeTheme();
    }

    private void Aboutus_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("", "", "ok");
    }

    private void FAQ_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new FAQPage());
    }

    private void ContactUs_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactUsPage());
    }

    private void Policies_Tapped(object sender, TappedEventArgs e)
    {
        PoliciesExpand.IsVisible = PoliciesExpand.IsVisible == true ? false : true;
        PoliciesArrow.Rotation = PoliciesArrow.Rotation == 270 ? 90 : 270;
    }
    private void Privacy_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PrivacyPolicyPage());
    }
    private void TermsConditions_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TermsConditionPage());
    }
}