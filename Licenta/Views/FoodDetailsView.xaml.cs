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
        var productName = nameLabel.Text; // Replace with the actual product name
        var productPrice = PriceLabel.Text; // Replace with the actual product price
         // Replace with the actual quantity selected by the user
        var productImage = imageLabel.Text;
        // Create a new item to add to the shopping cart
        CartItem newItem = new CartItem
        {
            Name = productName.ToString(),
            Price = productPrice.ToString(),
            Quantity = quantity,
            Image = productImage.ToString()
        };

        // Get the shopping cart service from the dependency service
        
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();
        if (shoppingCartService != null)
        {
            await shoppingCartService.AddItemToCartAsync(newItem);
            //DisplayAlert("Success", $"Added {quantity} {productName} to the cart.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "The shopping cart service is not available", "OK");
        }
    }
}