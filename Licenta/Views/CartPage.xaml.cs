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
    public CartPage()
    {
        InitializeComponent();
        BindingContext = this;
        CartItems = new ObservableCollection<CartItem>();
        cartListView.ItemsSource = CartItems;
        CartItems.CollectionChanged += CartItems_CollectionChanged;
    }
    private void CartItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        CalculateGrandTotal(); 
    }

    private void CalculateGrandTotal()
    {
        GrandTotal = CartItems.Sum(item => item.TotalPrice);
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
        CalculateGrandTotal();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();
        IEnumerable<CartItem> items = await shoppingCartService.GetCartItemsAsync();
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
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();
        await shoppingCartService.RemoveItemFromCartAsync(item);
        CartItems.Remove(item);
    }
    private async void OnDeleteItemTapped(object sender, EventArgs e)
    {
        var item = (sender as Image).BindingContext as CartItem;
        await DeleteItem(item);
    }
    public async Task ClearCart()
    {
        IShoppingCartService shoppingCartService = DependencyService.Get<IShoppingCartService>();
        await shoppingCartService.ClearCartAsync();
        CartItems.Clear();
        CalculateGrandTotal();
    }
}