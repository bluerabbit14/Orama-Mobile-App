namespace Orama_MAUI.Pages;

public partial class FAQPage : ContentPage
{
	public FAQPage()
	{
		InitializeComponent();
	}

    private void LabelOne_Tapped(object sender, TappedEventArgs e)
    {
        LabelOneContent.IsVisible = LabelOneContent.IsVisible == true ? false : true;
        LabeOneArrow.Rotation = LabeOneArrow.Rotation == 90 ? 270 : 90;
    }
    private void LabelTwo_Tapped(object sender, TappedEventArgs e)
    {
        LabelTwoContent.IsVisible = LabelTwoContent.IsVisible == true ? false : true;
        LabeTwoArrow.Rotation = LabeTwoArrow.Rotation == 90 ? 270 : 90;
    }
    private void LabelOneQuesOne_Tapped(object sender, TappedEventArgs e)
    {
        LabelOneAnswerOne.IsVisible = LabelOneAnswerOne.IsVisible==true? false : true;
    }
    private void LabelOneQuesTwo_Tapped(object sender, TappedEventArgs e)
    {
        LabelOneAnswerTwo.IsVisible = LabelOneAnswerTwo.IsVisible == true ? false : true;
    }
    private void LabelOneQuesThree_Tapped(object sender, TappedEventArgs e)
    {
        LabelOneAnswerThree.IsVisible = LabelOneAnswerThree.IsVisible == true ? false : true;
    }
    private void LabelTwoQuesOne_Tapped(object sender, TappedEventArgs e)
    {
        LabelTwoAnswerOne.IsVisible = LabelTwoAnswerOne.IsVisible == true ? false : true;
    }
    private void LabelTwoQuesTwo_Tapped(object sender, TappedEventArgs e)
    {
        LabelTwoAnswerTwo.IsVisible = LabelTwoAnswerTwo.IsVisible == true ? false : true;
    }
    private void LabelTwoQuesThree_Tapped(object sender, TappedEventArgs e)
    {
        LabelTwoAnswerThree.IsVisible = LabelTwoAnswerThree.IsVisible == true ? false : true;
    }
}