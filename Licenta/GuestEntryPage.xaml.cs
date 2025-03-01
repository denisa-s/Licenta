using Licenta.Models;

namespace Licenta;

public partial class GuestEntryPage : ContentPage
{
	public GuestEntryPage()
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
}