namespace Licenta;
using Licenta.Services;
using Licenta.ViewModels;
using Licenta.Views;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<AnimalService>();
        builder.Services.AddSingleton<FoodService>();
        builder.Services.AddTransient<AnimalsPageViewModel>();
        builder.Services.AddTransient<AnimalPage>();
        builder.Services.AddTransient<PetDetailsViewModel>();
        builder.Services.AddTransient<AnimalDetailsView>();

        builder.Services.AddTransient<ProductPageViewModel>();
        builder.Services.AddTransient<ProductPage>();
        builder.Services.AddTransient<FoodDetailsViewModel>();
        builder.Services.AddTransient<FoodDetailsView>();
        return builder.Build();
	}
}
