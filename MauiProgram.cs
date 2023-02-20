using Calculator.Pages.CurrencyConverter;
using Calculator.Pages.CurrencyConverter.Services;
using Calculator.Pages.SQLiteDemo.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Calculator;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddSingleton<SQLiteDemoPage>();
        builder.Services.AddTransient<IRateService, RateService>();
        builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
        builder.Services.AddSingleton<CurrencyConverter>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
