namespace Licenta.Views;
using Licenta.ViewModels;
public partial class FoodDetailsView : ContentPage
{
	public FoodDetailsView(FoodDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}