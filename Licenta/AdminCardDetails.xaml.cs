using Licenta.Models;

namespace Licenta;

public partial class AdminCardDetails : ContentPage
{
	public AdminCardDetails()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCardDetailsAsync();
    }
    async void OnCardAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminEntryCardDetails
        {
            BindingContext = new CardDetail()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AdminEntryCardDetails
            {
                BindingContext = e.SelectedItem as CardDetail
            });
        }
    }
}