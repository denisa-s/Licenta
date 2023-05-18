using Licenta.Models;
using Licenta.ViewModels;

namespace Licenta.Views;

public partial class PetDetailsView : ContentPage
{
	public PetDetailsView(PetDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private void OnMeetClicked(object sender, EventArgs e)
    {
        Pet globalpet = App.GlobalPet;
        globalpet.Name = nameLabel.Text;
        globalpet.Type = typeLabel.Text;
        globalpet.Gender = genderLabel.Text;
        globalpet.Breed = breedLabel.Text;
        Navigation.PushAsync(new AdoptionRequestPage());
    }
}