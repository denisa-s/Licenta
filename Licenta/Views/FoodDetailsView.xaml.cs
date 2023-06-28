namespace Licenta.Views;
using Licenta.ViewModels;
using System.Windows.Input;
using Licenta.Models;
using Licenta.Services;
public partial class FoodDetailsView : ContentPage
{
    int quantity = 1;
    public FoodDetailsView(FoodDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private async void OnAddClicked(object sender, EventArgs e)
    {
        var productName = nameLabel.Text; 
        var productPrice = PriceLabel.Text;
        var productImage = imageLabel.Text;
        CartItem newItem = new CartItem
        {
            Name = productName.ToString(),
            Price = productPrice.ToString(),
            Quantity = quantity,
            Image = productImage.ToString()
        };
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();
        if (shoppingCartService != null)
        {
            await shoppingCartService.AddItemToCartAsync(newItem);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "The shopping cart service is not available", "OK");
        }
    }
}