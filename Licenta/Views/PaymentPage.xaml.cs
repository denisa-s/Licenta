using Licenta.Models;

namespace Licenta.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
        List<DateTime> dates = new List<DateTime>();
        for (int i = 0; i < 300; i++)
        {
            dates.Add(DateTime.Today.AddMonths(i));
        }
        foreach (DateTime date in dates)
        {
            DatePicker.Items.Add(date.ToString("MM/yyyy"));
        }
    }
    private void OnDateSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedDate = DatePicker.SelectedItem as string;
        if (selectedDate != null)
        {
            DateTime dateValue = DateTime.ParseExact(selectedDate, "MM/yyyy", null);
            DisplayLabel.Text = dateValue.ToString("MM/yyyy");
        }
    }
    private async void OnFinishedClicked(object sender, EventArgs e)
	{
        var card = new CardDetail
        {
            CardNumber = CardNumberEntry.Text,
            CardHolder = CardHolderEntry.Text,
            ValidUntil = DisplayLabel.Text,
            SecurityCode = SecurityCodeEntry.Text,
            Email = App.GlobalObject.UserName
    };
        await App.Database.SaveCardDetail(card);
        await DisplayAlert("Confirmation", $"Transaction completed!", "OK"); ;
        await Navigation.PushAsync(new GuestEntryPage());
        await Navigation.PopToRootAsync();
    }
}