using Licenta.Models;

namespace Licenta;

public partial class GuestPage : ContentPage
{
	public GuestPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Guest)BindingContext;
        await App.Database.SaveGuestAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Guest)BindingContext;
        await App.Database.DeleteGuestAsync(slist);
        await Navigation.PopAsync();
    }
}