using Licenta.Models;
using Licenta.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Licenta.Views;

public partial class CheckoutPage : ContentPage
{
    public decimal GrandTotal { get; set; }
    public CheckoutPage(decimal grandTotal)
    {
        InitializeComponent();
        GrandTotal = grandTotal;
    }
   
    private async void OnSubmit(object sender, EventArgs e)
    {
        var order = new Order
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            ZipCode = ZipCodeEntry.Text,
            City = CityEntry.Text,
            Address = AddressEntry.Text,
            AddressDetails = AddressDetailsEntry.Text,
            PhoneNumber = PhoneNumberEntry.Text,
            Total = GrandTotal,
            Email = App.GlobalObject.UserName
        };
        if (CashButton.IsChecked)
        {
            order.PaymentMethod = "Cash on delivery";
            await App.Database.SaveOrder(order);
            await Navigation.PushAsync(new FoodEntryPage());
        }
        else if (CardButton.IsChecked)
        {
            order.PaymentMethod = "Credit card";
            await App.Database.SaveOrder(order);
            await Navigation.PushAsync(new PaymentPage());
        }
        else if (BankButton.IsChecked)
        {
            order.PaymentMethod = "Bank transfer";
            await App.Database.SaveOrder(order);
            await Navigation.PushAsync(new FoodEntryPage());
        }
    }
    
}