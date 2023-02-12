using DynamicLocalization.ViewModels;
using DynamicLocalization.Views;

namespace DynamicLocalization
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                
                //prism lifecycle methods are invoked here. I.E. OnInit, OnStart
               .UsePrism(prism => {
                    prism.RegisterTypes(containerRegistry =>
                    {
                        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
                        containerRegistry.RegisterForNavigation<AnotherPage, AnotherPageViewModel>();
                    });

                   prism.OnAppStart(async navigationService =>
                   {
                       var result = await navigationService.NavigateAsync("MainPage");
                       if (!result.Success)
                       {
                           System.Diagnostics.Debugger.Break();
                       }
                   });
               })

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            return builder.Build();
        }
    }
}