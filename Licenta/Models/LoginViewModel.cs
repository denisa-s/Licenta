using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Models;
using System.Windows.Input;
namespace Licenta.Models
{
    public class LoginViewModel
    {
        private string _userName, _password;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public ICommand RegisterCommand { private set; get; }

        public ICommand LoginCommand { private set; get; }

        private INavigation Navigation;

        public LoginViewModel(INavigation navigation)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            Navigation = navigation;
        }

        private async void OnLoginCommand(object obj)
        {
            var loginData = await App.Database.GetLoginDataAsync(UserName);
            if (loginData != null)
            {
                if (string.Equals(loginData.Password, Password))
                {
                    //await Navigation.PushModalAsync(new AppShell());
                    await App.Current.MainPage.DisplayAlert("Success", "Utilizator logat", "Ok");
                }
                else
                {
                    //await Navigation.PushModalAsync(new LoginPage());
                    await App.Current.MainPage.DisplayAlert("Failure", "Parola gresita. Incearca din nou", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Nume de utilizator invalid. Dacă nu ai un cont, înregistrează-te", "Ok");
            }
        }

        private void OnRegisterCommand(object obj)
        {
            LoginModel lm = new LoginModel();
            lm.UserName = UserName;
            lm.Password = Password;
            App.Database.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration successful", "Ok");
        }
    }
}
