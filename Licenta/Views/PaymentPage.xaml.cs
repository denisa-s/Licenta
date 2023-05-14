using Licenta.Models;

namespace Licenta.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
	}
    private async void OnFinishedClicked(object sender, EventArgs e)
	{
        var card = new CardDetail
        {
            CardNumber = CardNumberEntry.Text,
            CardHolder = CardHolderEntry.Text,
            ValidUntil = ValidUntilEntry.Text,
            SecurityCode = SecurityCodeEntry.Text,
            Email = App.GlobalObject.UserName
    };
        await App.Database.SaveCardDetail(card);
        await Navigation.PushAsync(new MedicalRecordEntryPage());
    }
}