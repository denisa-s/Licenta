namespace Licenta.Views;
using Licenta.Models;
using Licenta.ViewModels;
using Licenta.Views;
public partial class HomePage : ContentPage
{
    public HomePageViewModel viewModel;

    public HomePage()
    {
    }

    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void Donate_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TestPage());
    }


    /*private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var pet = ((VisualElement)sender).BindingContext as Pet;

        if (pet == null)
            return;
        await Shell.Current.GoToAsync(nameof(PetDetailsView), true, new Dictionary<string, object>
        {
            {"Pet", pet }
        });
    }*/
}