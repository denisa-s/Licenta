using Licenta.Models;
using System.Security.Cryptography;

namespace Licenta;

public partial class GuestEntryPage : ContentPage
{
    public string email { get; set; }
    public GuestEntryPage()
    {
        InitializeComponent();
        email = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        emailLabel.Text = result.UserName;
        passwordEntry.Text = result.Password;
    }

    async void OnGuestAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuestPage
        {
            BindingContext = new Guest()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new GuestPage
            {
                BindingContext = e.SelectedItem as Guest
            });
        }
    }
    async void OnPetProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetProfile
        {
            BindingContext = new Dog()
        });
    }
    async void OnPersonalInfoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonalInfo
        {
            BindingContext = new Guest()
        });

    }
    async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        email = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(email);
        LoginModel result = loginData.Result;
        result.Password = HashPassword(passwordEntry.Text);
        await App.Database.SaveUserDataAsync(result);
        await Navigation.PushAsync(new GuestEntryPage());
    }
    public static string HashPassword(string password)
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        byte[] hash = HashPasswordWithSalt(password, salt);

        var combinedSaltAndHash = new byte[salt.Length + hash.Length];
        Array.Copy(salt, 0, combinedSaltAndHash, 0, salt.Length);
        Array.Copy(hash, 0, combinedSaltAndHash, salt.Length, hash.Length);

        return Convert.ToBase64String(combinedSaltAndHash);
    }
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        const int iterations = 10000;
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
        {
            return pbkdf2.GetBytes(20); // 20 bytes for SHA1
        }
    }
}