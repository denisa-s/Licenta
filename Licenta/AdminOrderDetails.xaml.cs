using Licenta.Models;

namespace Licenta;

public partial class AdminOrderDetails : ContentPage
{
	public AdminOrderDetails()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetOrdersAsync();
    }

    async void OnOrderAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminEntryOrderDetails
        {
            BindingContext = new Order()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AdminEntryOrderDetails
            {
                BindingContext = e.SelectedItem as Order
            });
        }
    }
}