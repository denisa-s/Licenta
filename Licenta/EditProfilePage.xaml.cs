using Licenta.Models;

namespace Licenta;

public partial class EditProfilePage : ContentPage
{
    public string email { get; set; }
    public EditProfilePage()
	{
		InitializeComponent();
        email = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        firstNameEntry.Text = result.FirstName;
        lastNameEntry.Text = result.LastName;
        phoneNumberEntry.Text = result.PhoneNumber;
        addressEntry.Text = result.Address;
        birthDateEntry.Text = result.BirthDate;
        detailsEntry.Text = result.AddressDetails;
        housingTypeEntry.Text = result.HousingType;
        maritalStatusEntry.Text = result.MaritalStatus;
    }
    async void OnSaveProfileClicked(object sender, EventArgs e)
    {
        email = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        result.Address = addressEntry.Text;
        result.AddressDetails = detailsEntry.Text;
        result.BirthDate = birthDateEntry.Text;
        result.FirstName = firstNameEntry.Text;
        result.HousingType = housingTypeEntry.Text;
        result.LastName = lastNameEntry.Text;
        result.MaritalStatus = maritalStatusEntry.Text;
        result.PhoneNumber = phoneNumberEntry.Text;
        await App.Database.SaveUserDataAsync(result);
        await Navigation.PushAsync(new PersonalInfo());
    }
    async void OnLoginnSecurityClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuestEntryPage
        {
            BindingContext = new Guest()
        });
    }
   
    async void OnPersonalInfoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonalInfo
        {
            BindingContext = new Guest()
        });
    }
}