using Licenta.Models;

namespace Licenta;

public partial class ProviderEntryPage : ContentPage
{
	public ProviderEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProvidersAsync();
    }
    async void OnProviderAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProviderPage
        {
            BindingContext = new Provider()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProviderPage
            {
                BindingContext = e.SelectedItem as Provider
            });
        }
    }
}