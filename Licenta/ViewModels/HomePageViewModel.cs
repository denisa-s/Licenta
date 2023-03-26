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
    public partial class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Pet> Pets { get; } = new();
        PetService petService;
        public HomePageViewModel(PetService petService)
        {
            Title = "Alege viitorul tau cel mai bun prieten";
            this.petService = petService;
        }

        [ObservableProperty]
        bool isRefreshing = true;

        [ObservableProperty]
        Pet selectedPet;

        [RelayCommand]
        async Task GetPetsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Console.WriteLine("Cauta animale");

                var pets = await petService.GetPets();

                if (Pets.Count != 0)
                    Pets.Clear();

                foreach (var pet in pets)
                    Pets.Add(pet);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Pets: {ex.Message}");
                Console.WriteLine("Nu s au gasit animale");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task GoToDetails()
        {
            if (selectedPet == null)
                return;

            var data = new Dictionary<string, object>
            {
                {"Pet", selectedPet }
            };

            await Shell.Current.GoToAsync(nameof(PetDetailsView), true, data);
        }
    }
}
