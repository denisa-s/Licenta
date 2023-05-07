namespace Licenta.Views;
using CommunityToolkit.Mvvm.Input;
using Licenta.Models;
using Licenta.ViewModels;
using Licenta.Views;
public partial class ProductPage : ContentPage
{
    public ProductPageViewModel viewModel;

    public ProductPage()
    {
    }

    public ProductPage(ProductPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var food = ((VisualElement)sender).BindingContext as Food;

        if (food == null)
            return;
        await Shell.Current.GoToAsync(nameof(FoodDetailsView), true, new Dictionary<string, object>
        {
            {"Food", food }
        });
    }
}