using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public partial class AppShellViewModel
    {
        [ICommand]
        async void SignOut()
        {

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
