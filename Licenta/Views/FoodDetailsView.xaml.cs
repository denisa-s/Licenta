namespace Licenta.Views;
using Licenta.ViewModels;
using System.Windows.Input;
using Licenta.Models;
using Licenta.Services;
public partial class FoodDetailsView : ContentPage
{
    public FoodDetailsView(FoodDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}