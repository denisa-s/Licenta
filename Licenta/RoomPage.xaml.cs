using Licenta.Models;

namespace Licenta;

public partial class RoomPage : ContentPage
{
	public RoomPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Room)BindingContext;
        await App.Database.SaveRoomAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Room)BindingContext;
        await App.Database.DeleteRoomAsync(slist);
        await Navigation.PopAsync();
    }
}