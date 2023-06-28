using Licenta.Models;

namespace Licenta.Views;

public partial class AdoptionRequestPage : ContentPage
{
	public AdoptionRequestPage()
	{
		InitializeComponent();
        List<DateTime> dates = new List<DateTime>();
        for (int i = 0; i < 100; i++)
        {
            dates.Add(DateTime.Today.AddDays(i));
        }

        // Add the dates to the picker
        foreach (DateTime date in dates)
        {
            DatePicker.Items.Add(date.ToString("dd/MM/yyyy"));
        }
    }
    private void OnDateSelectedIndexChanged(object sender, EventArgs e)
    {
        // Retrieve the selected date from the picker
        string selectedDate = DatePicker.SelectedItem as string;
        if (selectedDate != null)
        {
            DateTime dateValue = DateTime.ParseExact(selectedDate, "dd/MM/yyyy", null);

            // Use the selected date as needed
            // For example, display it in a label
            DisplayLabel.Text = dateValue.ToString("dd/MM/yyyy");
        }
    }
    protected override async void OnAppearing()
    {
        var loginData = await App.Database.RetrieveDataFromDatabase(App.GlobalObject.UserName);
        LoginModel result = loginData;
        FirstNameEntry.Text = result.FirstName;
        LastNameEntry.Text = result.LastName;
        PhoneNumberEntry.Text = result.PhoneNumber;
        AddressEntry.Text = result.Address;
        AddressDetailsEntry.Text = result.AddressDetails;
        TypeEntry.Text = App.GlobalAnimal.Type;
        BreedEntry.Text = App.GlobalAnimal.Breed;
        NameEntry.Text = App.GlobalAnimal.Name;
        GenderEntry.Text = App.GlobalAnimal.Gender;
        EmailEntry.Text = App.GlobalObject.UserName;
    }
    private async void OnSubmit(object sender, EventArgs e)
    {
        var request = new AdoptRequest
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Address = AddressEntry.Text,
            AddressDetails = AddressDetailsEntry.Text,
            PhoneNumber = PhoneNumberEntry.Text,
            Email = App.GlobalObject.UserName,
            CNP = CNPEntry.Text,
            Type = App.GlobalAnimal.Type,
            Breed = App.GlobalAnimal.Breed,
            Name = App.GlobalAnimal.Name,
            Gender = App.GlobalAnimal.Gender,
            Date = DisplayLabel.Text
        };
            await App.Database.SaveAdoptionRequestAsync(request);
            await DisplayAlert("Confirmation", $"Request submitted!", "OK"); ;
        //await Navigation.PushAsync(new GuestEntryPage());
        //await Navigation.PopToRootAsync();
        Navigation.PopAsync();
    }
}