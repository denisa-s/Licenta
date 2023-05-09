using Licenta.Models;
using Licenta.Services;
using System.Collections.ObjectModel;

namespace Licenta.Views;

public partial class CartPage : ContentPage 
{
    public ObservableCollection<CartItem> CartItems { get; set; }

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
    }
    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }
}