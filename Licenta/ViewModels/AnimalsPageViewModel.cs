using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Licenta.Models;
using Licenta.Services;
using Licenta.Views;

namespace Licenta.ViewModels
{
    public partial class AnimalsPageViewModel :BaseViewModel
    {
        public ObservableCollection<Animal> Animals { get; } = new ObservableCollection<Animal>();
        AnimalService serv;
        public AnimalsPageViewModel(AnimalService serv)
        {
            this.serv = serv;
        }

        [ObservableProperty]
        bool isRefreshing = true;

        [ObservableProperty]
        Animal selected;

        [RelayCommand]
        async Task GetAnimalsAsync()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                IsLoading = true;
                var animals = await serv.GetAnimals();
                if (Animals.Count != 0)
                    Animals.Clear();
                foreach (var animal in animals)
                    Animals.Add(animal);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Failure!", "There was a failure", "OK");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToDetails()
        {
            if (selected != null)
            {
                var info = new Dictionary<string, object>
                {
                     {"Animal", selected}
                };

                await Shell.Current.GoToAsync(nameof(AnimalDetailsView), true, info);
            }
        }
    }
}
