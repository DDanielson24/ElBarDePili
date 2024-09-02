using ElBarDePili.Services;
using ElBarDePili.ViewModels;
using ElBarDePili.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ElBarDePili
{
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

            builder.Services.AddSingleton<DataBaseService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<Recetas>();
            builder.Services.AddSingleton<RecetasViewModel>();

            builder.Services.AddTransient<RecetasDetails>();
            builder.Services.AddTransient<RecetasDetailsViewModel>();

            builder.Services.AddTransient<RecetasEditing>();
            builder.Services.AddTransient<RecetasEditingViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
