using System.Threading.Tasks;

namespace Orama_MAUI.Pages;

public partial class ContactusPage : ContentPage
{
	public ContactusPage()
	{
		InitializeComponent();
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Contact us", "Navigate to gmail dashboard !", "Ok");
    }
}