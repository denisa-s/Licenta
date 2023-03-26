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
        Routing.RegisterRoute(nameof(PetDetailsView), typeof(PetDetailsView));
    }   
}

