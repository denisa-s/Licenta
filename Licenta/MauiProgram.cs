﻿namespace Licenta;

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
        builder.Services.AddSingleton<DogEntryPage>();
        builder.Services.AddSingleton<EmployeeEntryPage>();
        return builder.Build();
	}
}
