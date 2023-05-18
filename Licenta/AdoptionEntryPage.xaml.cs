using Licenta.Models;

namespace Licenta;

public partial class AdoptionEntryPage : ContentPage
{
	public AdoptionEntryPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (AdoptRequest)BindingContext;
        await App.Database.SaveAdoptionRequestAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (AdoptRequest)BindingContext;
        await App.Database.DeleteAdoptionRequestAsync(slist);
        await Navigation.PopAsync();
    }
}