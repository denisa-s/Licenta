using Licenta.Models;
using Licenta.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Licenta.Views;

public partial class CheckoutPage : ContentPage
{
    
    public CheckoutPage()
    {
        InitializeComponent();
    }
    private async void OnSubmit(object sender, EventArgs e)
    {
        if (CashButton.IsChecked)
        {
            await Navigation.PushAsync(new FoodPage());
        }
        else if (CardButton.IsChecked)
        {
            await Navigation.PushAsync(new PaymentPage());
        }
        else if (BankButton.IsChecked)
        {
            await Navigation.PushAsync(new FoodPage());
        }
    }
}