using DynamicLocalization.ViewModels;
using DynamicLocalization.Views;
using Prism.Commands;

namespace DynamicLocalization
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism => {
                    prism.RegisterTypes(containerRegistry =>
                    {
                        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
                        containerRegistry.RegisterForNavigation<AnotherPage, AnotherPageViewModel>();
                    });})
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}