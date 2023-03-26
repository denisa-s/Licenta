using Licenta.ViewModels;

namespace Licenta.Views;

public partial class PetDetailsView : ContentPage
{
	public PetDetailsView(PetDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}