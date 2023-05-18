using Licenta.Models;

namespace Licenta;

public partial class AdminEntryGuestDetails : ContentPage
{
	public AdminEntryGuestDetails()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (LoginModel)BindingContext;
        await App.Database.SaveUserDataAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (LoginModel)BindingContext;
        await App.Database.DeleteGuestAsync(slist);
        await Navigation.PopAsync();
    }
}