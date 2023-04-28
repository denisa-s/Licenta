using Licenta.Models;
using System.Xml;

namespace Licenta;

public partial class PersonalInfo : ContentPage
{
    public string email { get; set; }
	public PersonalInfo()
	{
		InitializeComponent();
        email = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        firstNameLabel.Text = result.FirstName;
        lastNameLabel.Text = result.LastName;
        phoneNumberLabel.Text = result.PhoneNumber;
        addressLabel.Text = result.Address;
        birthdateLabel.Text = result.BirthDate;
        detailsLabel.Text = result.AddressDetails;
        housingTypeLabel.Text = result.HousingType;
        maritalStatusLabel.Text = result.MaritalStatus;
    }
    /*protected override void OnAppearing()
    {
        base.OnAppearing();
        email = App.GlobalObject.UserName;
        var loginData =  App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        firstNameLabel.Text = result.FirstName;
        lastNameLabel.Text = result.LastName;
        phoneNumberLabel.Text = result.PhoneNumber;
        addressLabel.Text = result.Address;
        birthdateLabel.Text = result.BirthDate.ToShortDateString();
        detailsLabel.Text = result.AddressDetails;
        housingTypeLabel.Text = result.HousingType;
        maritalStatusLabel.Text = result.MaritalStatus;
    }*/
    async void OnEditProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditProfilePage
        {
            BindingContext = new LoginModel()
        });
    }
    async void OnLoginnSecurityClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new GuestEntryPage
        {
            BindingContext = new Guest()
        });
    }
    async void OnPetProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetProfile
        {
            BindingContext = new Dog()
        });
    }
}