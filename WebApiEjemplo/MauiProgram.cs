﻿using Microsoft.Extensions.Logging;
using WebApiEjemplo.Data;
using WebApiEjemplo.Services;

namespace WebApiEjemplo;

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
			});
		
        builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<IProductService, ProductService>();
		builder.Services.AddSingleton<ICategoriasService, CategoriasService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
