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
    [QueryProperty(nameof(Food), "Food")]
    public partial class FoodDetailsViewModel : BaseViewModel
    {
        public FoodDetailsViewModel()
        {
        }

        [ObservableProperty]
        Food food;
        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
