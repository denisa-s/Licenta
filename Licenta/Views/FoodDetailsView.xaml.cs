namespace Licenta.Views;
using Licenta.ViewModels;
using System.Windows.Input;

public partial class FoodDetailsView : ContentPage
{
    public FoodDetailsView(FoodDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}