namespace Licenta;
using Licenta.Models;
using Microsoft.Maui.Controls;

public partial class DogPage : ContentPage
{
	public DogPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Dog)BindingContext;
        await App.Database.SaveDogAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Dog)BindingContext;
        await App.Database.DeleteDogAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SizePage((Dog)this.BindingContext)
        {
            BindingContext = new Size()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var dog = (Dog)BindingContext;
        listView.ItemsSource = await App.Database.GetListSizesAsync(dog.ID);
    }
    /*async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Size product;
        var shopList = (Dog)BindingContext;
        if (listView.SelectedItem != null)
        {
            product = listView.SelectedItem as Size;
            var listProductAll = await App.Database.GetSizesAsync();
            var listProduct = listProductAll.FindAll(x => x.ID == product.ID);
            await App.Database.DeleteListSizeAsync(listProduct.FirstOrDefault);
            await Navigation.PopAsync();
        }

    }*/
}