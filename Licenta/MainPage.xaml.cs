namespace Licenta;
using Licenta.ViewModels;
using Licenta.Views;
using Licenta.Models;
using Licenta.Services;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AnimalDetailsView), typeof(AnimalDetailsView));
        Routing.RegisterRoute(nameof(FoodDetailsView), typeof(FoodDetailsView));
    }   
}

