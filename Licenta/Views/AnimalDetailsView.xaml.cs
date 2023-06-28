namespace Licenta.Views;
using Licenta.ViewModels;
using Licenta.Models;
public partial class AnimalDetailsView : ContentPage
{
    public AnimalDetailsView(PetDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    private void OnMeetClicked(object sender, EventArgs e)
    {
        Animal globalanimal = App.GlobalAnimal;
        globalanimal.Name = nameLabel.Text;
        globalanimal.Type = typeLabel.Text;
        globalanimal.Gender = genderLabel.Text;
        globalanimal.Breed = breedLabel.Text;
        Navigation.PushAsync(new AdoptionRequestPage());
    }
    public AnimalDetailsView()
	{
		InitializeComponent();
	}
	
}