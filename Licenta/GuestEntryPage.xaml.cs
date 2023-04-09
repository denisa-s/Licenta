using Licenta.Models;

namespace Licenta;

public partial class GuestEntryPage : ContentPage
{
    /*private string _userName, _password;

    public string UserName { get => _userName; set => _userName = value; }
    public string Password { get => _password; set => _password = value; }*/
    public GuestEntryPage()
	{
		InitializeComponent();
	}
    /*protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGuestsAsync();
    }*/
    async void OnGuestAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuestPage
        {
            BindingContext = new Guest()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new GuestPage
            {
                BindingContext = e.SelectedItem as Guest
            });
        }
    }
    async void OnPetProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetProfile
        {
            BindingContext = new Dog()
        });
    }
    async void OnPersonalInfoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonalInfo
        {
            BindingContext = new Guest()
        });

    }
    /*async void OnEditEmailClicked(object sender, EventArgs e)
    {

        var loginData = await App.Database.GetLoginDataAsync(UserName);
        if (loginData != null)
        {
            if (string.Equals(loginData.UserName, UserName))
            {
                
            }
            
        }
    }*/
}