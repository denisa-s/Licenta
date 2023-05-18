namespace Licenta;
using Licenta.Models;
public partial class AdoptionRequest : ContentPage
{
	public AdoptionRequest()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetAdoptionRequestsAsync();
    }
    async void OnRequestAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdoptionEntryPage
        {
            BindingContext = new AdoptRequest()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AdoptionEntryPage
            {
                BindingContext = e.SelectedItem as AdoptRequest
            });
        }
    }
}