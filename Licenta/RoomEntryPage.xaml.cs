using Licenta.Models;

namespace Licenta;

public partial class RoomEntryPage : ContentPage
{
	public RoomEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    async void OnRoomAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoomPage
        {
            BindingContext = new Room()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RoomPage
            {
                BindingContext = e.SelectedItem as Room
            });
        }
    }
}