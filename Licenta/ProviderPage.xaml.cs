using Licenta.Models;

namespace Licenta;

public partial class ProviderPage : ContentPage
{
	public ProviderPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Provider)BindingContext;
        await App.Database.SaveProviderAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Provider)BindingContext;
        await App.Database.DeleteProviderAsync(slist);
        await Navigation.PopAsync();
    }
}