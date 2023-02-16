namespace Licenta;
using Licenta.Models;
public partial class DogEntryPage : ContentPage
{
	public DogEntryPage()
	{
		InitializeComponent();

	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetDogsAsync();
    }
    async void OnDogAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DogPage
        {
            BindingContext = new Dog()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new DogPage
            {
                BindingContext = e.SelectedItem as Dog
            });
        }
    }
}