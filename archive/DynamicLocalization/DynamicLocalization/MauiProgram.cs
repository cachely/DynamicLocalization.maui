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
                    prism.RegisterTypes(container =>
                    {
                        container.RegisterForNavigation<MainPage, MainPageViewModel>();
                        container.RegisterForNavigation<AnotherPage, AnotherPageViewModel>();
                    });

                   prism.OnAppStart(navigationService =>
                   {
                       navigationService.CreateBuilder().AddSegment<MainPageViewModel>().Navigate(HandleNavigationError);                      
                   });
               })

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            return builder.Build();
        }

        private static void HandleNavigationError(Exception ex)
        {
            Console.WriteLine(ex);
            System.Diagnostics.Debugger.Break();
        }
    }
}