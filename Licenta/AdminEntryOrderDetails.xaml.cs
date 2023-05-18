using Licenta.Models;

namespace Licenta;

public partial class AdminEntryOrderDetails : ContentPage
{
	public AdminEntryOrderDetails()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Order)BindingContext;
        await App.Database.SaveOrder(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Order)BindingContext;
        await App.Database.DeleteOrderAsync(slist);
        await Navigation.PopAsync();
    }
}