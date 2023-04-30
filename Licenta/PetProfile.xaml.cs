using Licenta.Models;

namespace Licenta;

public partial class PetProfile : ContentPage
{
	public PetProfile()
	{
		InitializeComponent();
	}
    async void OnLoginnSecurityClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuestEntryPage
        {
            BindingContext = new Guest()
        });
    }
    async void OnPersonalInfoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonalInfo
        {
            BindingContext = new Guest()
        });
    }
    
}