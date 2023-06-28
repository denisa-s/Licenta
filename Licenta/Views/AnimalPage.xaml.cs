namespace Licenta.Views;
using Licenta.ViewModels;
public partial class AnimalPage : ContentPage
{
    public AnimalsPageViewModel viewModel;

    public AnimalPage()
    {
    }

    public AnimalPage(AnimalsPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void Donate_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TestPage());
    }
    
}