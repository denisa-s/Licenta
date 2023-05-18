using Licenta.Models;

namespace Licenta;

public partial class AdminEntryCardDetails : ContentPage
{
	public AdminEntryCardDetails()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (CardDetail)BindingContext;
        await App.Database.SaveCardDetail(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (CardDetail)BindingContext;
        await App.Database.DeleteCardAsync(slist);
        await Navigation.PopAsync();
    }
}