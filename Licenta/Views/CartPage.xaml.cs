using Licenta.Models;
using Licenta.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Licenta.Views;

public partial class CartPage : ContentPage 
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    public decimal GrandTotal { get; set; }
    // Constructor of the content page
    public CartPage()
    {
        InitializeComponent();

        // Set the BindingContext to the current instance
        BindingContext = this;

        // Create a new ObservableCollection to hold the CartItems
        CartItems = new ObservableCollection<CartItem>();

        // Bind the ListView to the CartItems collection
        cartListView.ItemsSource = CartItems;
        CartItems.CollectionChanged += CartItems_CollectionChanged;
        
    }
    private void CartItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        CalculateGrandTotal(); 
    }

    private void CalculateGrandTotal()
    {
        // Calculate the GrandTotal by summing the TotalPrice of each CartItem in the CartItems collection
        GrandTotal = CartItems.Sum(item => item.TotalPrice);

        // Notify the UI that the GrandTotal property has changed
        OnPropertyChanged(nameof(GrandTotal));
    }
    private void OnCartItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CartItem.TotalPrice))
        {
            CalculateGrandTotal();
        }
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var item = ((Stepper)sender).BindingContext as CartItem;
        item.Quantity = (int)e.NewValue;

        // Call the CalculateGrandTotal method to recalculate the GrandTotal
        CalculateGrandTotal();
    }

    // Implement the OnAppearing method to retrieve the CartItems from the IShoppingCartService
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Get the shopping cart service from the dependency service
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();

        // Get the CartItems from the shopping cart service
        IEnumerable<CartItem> items = await shoppingCartService.GetCartItemsAsync();

        // Clear the existing items in the CartItems collection and add the new items
        CartItems.Clear();
        foreach (CartItem item in items)
        {
            CartItems.Add(item);
        }
        CalculateGrandTotal();

    }
    private async void OnCheckoutClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new CheckoutPage(GrandTotal));
        await ClearCart();
    }
   
    private async Task DeleteItem(CartItem item)
    {
        // Get the shopping cart service from the dependency service
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();

        // Remove the item from the cart
        await shoppingCartService.RemoveItemFromCartAsync(item);

        // Remove the item from the CartItems collection
        CartItems.Remove(item);
    }
    private async void OnDeleteItemTapped(object sender, EventArgs e)
    {
        // Get the selected item from the command parameter
        var item = (sender as Image).BindingContext as CartItem;

        // Call the DeleteItem method with the selected item
        await DeleteItem(item);
    }
    public async Task ClearCart()
    {
        // Get the shopping cart service from the dependency service
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();

        // Remove all items from the cart
        await shoppingCartService.ClearCartAsync();

        // Remove all items from the CartItems collection
        CartItems.Clear();

        // Recalculate the grand total
        CalculateGrandTotal();
    }



}