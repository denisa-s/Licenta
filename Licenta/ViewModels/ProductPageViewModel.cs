﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Licenta.Models;
using Licenta.Services;
using Licenta.Views;

namespace Licenta.ViewModels
{
    public partial class ProductPageViewModel : BaseViewModel
    {
        public ObservableCollection<Food> Foods { get; } = new();
        FoodService foodService;
        public ProductPageViewModel(FoodService foodService)
        {
            Title = "Alege mancarea pt animalul tau";
            this.foodService = foodService;
        }

        [ObservableProperty]
        bool isRefreshing = true;

        [ObservableProperty]
        Food selectedFood;

        [RelayCommand]
        async Task GetFoodsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Console.WriteLine("Cauta mancare");

                var foods = await foodService.GetFoods();

                if (Foods.Count != 0)
                    Foods.Clear();

                foreach (var food in foods)
                    Foods.Add(food);

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
            if (selectedFood == null)
                return;

            var data = new Dictionary<string, object>
            {
                {"Food", selectedFood }
            };

            await Shell.Current.GoToAsync(nameof(FoodDetailsView), true, data);
        }
        [RelayCommand]
        async Task CartCommand()
        {
            await Shell.Current.GoToAsync("//cart");
        }
    }
}
