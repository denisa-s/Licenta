namespace Licenta;
using Licenta.Models;
using Licenta.Views;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();
        Routing.RegisterRoute(nameof(AnimalDetailsView), typeof(AnimalDetailsView));
        Routing.RegisterRoute(nameof(FoodDetailsView), typeof(FoodDetailsView));
    }
   
}
