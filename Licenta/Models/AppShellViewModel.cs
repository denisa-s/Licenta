using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.ViewModels;
using Licenta.Views;
namespace Licenta.Models
{
    public partial class AppShellViewModel
    {
        [ICommand]
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        [ICommand]
        async void GetStarted()
        {
            await Shell.Current.GoToAsync($"//{nameof(GuestEntryPage)}");
        }
    }
}
