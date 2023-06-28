using System;
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
        public ObservableCollection<Food> Foods { get; } = new ObservableCollection<Food>();
        FoodService foodService;
        public ProductPageViewModel(FoodService foodService)
        {
            this.foodService = foodService;
        }

        [ObservableProperty]
        bool isRefreshing = true;

        [ObservableProperty]
        Food selectedFood;

        [RelayCommand]
        async Task GetFoodsAsync()
        {
            if (IsLoading)
                return;

            try
            {
                IsLoading = true;
                var foods = await foodService.GetFoods();
                if (Foods.Count != 0)
                    Foods.Clear();
                foreach (var food in foods)
                    Foods.Add(food);
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
            if (selectedFood != null)
            {
                var info = new Dictionary<string, object>
                    {
                        {"Food", selectedFood }
                    };
                await Shell.Current.GoToAsync(nameof(FoodDetailsView), true, info);
            }
        }
        [RelayCommand]
        async Task CartCommand()
        {
            await Shell.Current.GoToAsync("//cart");
        }
    }
}
