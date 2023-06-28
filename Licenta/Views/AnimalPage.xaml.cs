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

    private async void TestClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TestPage());
    }
    
}