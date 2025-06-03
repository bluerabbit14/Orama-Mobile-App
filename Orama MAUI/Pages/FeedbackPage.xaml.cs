using CommunityToolkit.Maui.Converters;
using Orama_MAUI.ViewModels;

namespace Orama_MAUI.Pages;

public partial class FeedbackPage : ContentPage
{
	public FeedbackPage()
	{
		InitializeComponent();
		BindingContext = new FeedbackViewModel();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var titleValue=TitleEntry.Text?.Trim();
        var DescriptionValue =DescriptionEntry.Text?.Trim();

		if(string.IsNullOrWhiteSpace(titleValue))
		{
			DisplayAlert("FeedBack","Enter Title","Ok");
		}
        if (string.IsNullOrWhiteSpace(DescriptionValue))
        {
            DisplayAlert("FeedBack", "Enter Title", "Ok");
        }
    }
}