namespace Orama_MAUI.Pages;

public partial class ContactUsPage : ContentPage
{
	public ContactUsPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new ChatPage());
    }
}