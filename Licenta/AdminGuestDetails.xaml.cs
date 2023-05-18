using Licenta.Models;

namespace Licenta;

public partial class AdminGuestDetails : ContentPage
{
	public AdminGuestDetails()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGuestsAsync();
    }

    async void OnGuestAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminEntryGuestDetails
        {
            BindingContext = new LoginModel()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AdminEntryGuestDetails
            {
                BindingContext = e.SelectedItem as LoginModel
            });
        }
    }
}