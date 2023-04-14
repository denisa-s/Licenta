using Licenta.Models;
using System.Xml;

namespace Licenta;

public partial class PersonalInfo : ContentPage
{
	public PersonalInfo()
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
    async void OnPetProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetProfile
        {
            BindingContext = new Dog()
        });
    }
}