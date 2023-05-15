using CommunityToolkit.Mvvm.Input;
using Licenta.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.ViewModels
{
    [QueryProperty(nameof(Pet), "Pet")]
    public partial class PetDetailsViewModel : BaseViewModel
    {
        public PetDetailsViewModel()
        {
        }

        [ObservableProperty]
        Pet pet;
        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
