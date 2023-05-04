using Licenta.Models;

namespace Licenta;

public partial class FoodEntryPage : ContentPage
{
	public FoodEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //listView.ItemsSource = await App.Database.GetFoodsAsync();
    }
    async void OnFoodAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage
        {
            BindingContext = new Food()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new FoodPage
            {
                BindingContext = e.SelectedItem as Food
            });
        }
    }
}