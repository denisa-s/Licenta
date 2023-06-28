using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Licenta.Models
{
    public class RegisterViewModel
    {
        private string userName, password, firstName, lastName, phoneNumber;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public ICommand RegisterCommand { private set; get; }

        private INavigation Navigation;

        public RegisterViewModel(INavigation navigation)
        {
            RegisterCommand = new Command(OnRegisterCommand);
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
            lm.FirstName = FirstName;
            lm.LastName = LastName;
            lm.PhoneNumber = PhoneNumber;
            App.Database.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration successful", "Ok");
        }
    }
}
