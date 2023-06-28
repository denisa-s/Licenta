using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Models;
using System.Windows.Input;
using System.Security.Cryptography;
namespace Licenta.Models
{
    public class LoginViewModel
    {
        private string userName, password;
      
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public ICommand RegisterCommand { private set; get; }
        
        public ICommand LoginCommand { private set; get; }

        private INavigation Navigation;

        public LoginViewModel(INavigation navigation)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            Navigation = navigation;
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashedPasswordBytes, 0, salt, 0, 16);

            byte[] hash = HashPasswordWithSalt(password, salt);

            for (int i = 0; i < 20; i++)
            {
                if (hashedPasswordBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
        private async void OnLoginCommand(object obj)
        {
            var loginData = await App.Database.GetLoginDataAsync(UserName);
            if (loginData != null)
            {
                if (VerifyPassword(Password, loginData.Password))
                {
                    await App.Current.MainPage.DisplayAlert("Success", "You are logged in", "Ok");
                    if (App.GlobalObject.UserName == "admin")
                    { await Shell.Current.GoToAsync($"//{nameof(AdminCardDetails)}"); }
                    else { await Shell.Current.GoToAsync($"//{nameof(MainPage)}"); }
                }
                else
                {
                    bool answer = await App.Current.MainPage.DisplayAlert("Failure", "Wrong password. Try again", "Try again", "Forgot Password");
                    if (answer)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }
                }
            }
            else
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Failure", "Invalid username. If you don't have an account, register", "Try again", "Register");
                if (answer)
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
            }
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
            using (var x = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return x.GetBytes(20);
            }
        }
        private void OnRegisterCommand(object obj)
        {
            LoginModel lm = new LoginModel();
            lm.UserName = UserName;
            lm.Password = HashPassword(Password);
            App.Database.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration successful", "Ok");
        }
    }
}
