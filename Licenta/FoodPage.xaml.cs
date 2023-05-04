using Licenta.Models;

namespace Licenta;

public partial class FoodPage : ContentPage
{
	public FoodPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Food)BindingContext;
       // await App.Database.SaveFoodAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Food)BindingContext;
       // await App.Database.DeleteFoodAsync(slist);
        await Navigation.PopAsync();
    }
}