using DynamicLocalization.ViewModels;
using DynamicLocalization.Views;

namespace DynamicLocalization;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.UsePrism(prism => ConfigurePrism(prism))
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

	private static void ConfigurePrism(PrismAppBuilder prism)
	{
        prism.RegisterTypes(container =>
        {
            container.RegisterForNavigation<MainPage, MainPageViewModel>();
            container.RegisterForNavigation<AnotherPage, AnotherPageViewModel>();
        });

        prism.OnAppStart(navigationService =>
        {
            navigationService.CreateBuilder().AddSegment<MainPageViewModel>().Navigate(HandleNavigationError);
        });
    }
    private static void HandleNavigationError(Exception ex)
    {
        Console.WriteLine(ex);
        System.Diagnostics.Debugger.Break();
    }
}
