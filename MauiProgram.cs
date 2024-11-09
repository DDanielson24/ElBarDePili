using ElBarDePili.Database;
using ElBarDePili.ViewModels;
using ElBarDePili.ViewModels.Ingredientes;
using ElBarDePili.ViewModels.Recetas;
using ElBarDePili.Views;
using ElBarDePili.Views.Calculador;
using ElBarDePili.Views.Recetas;
using ElBarDePili.Views.Ingredientes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ElBarDePili.ViewModels.Calculador;
using DevExpress.Maui;

namespace ElBarDePili
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseDevExpressEditors()
                .UseDevExpressCollectionView()
                .UseDevExpressControls()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ElBarDePiliDatabase>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<Calculador>();
            builder.Services.AddSingleton<CalculadorViewModel>();

            builder.Services.AddSingleton<RecetasList>();
            builder.Services.AddSingleton<RecetasViewModel>();

            builder.Services.AddTransient<RecetasDetails>();
            builder.Services.AddTransient<RecetasDetailsViewModel>();

            builder.Services.AddTransient<RecetasEditing>();
            builder.Services.AddTransient<RecetasEditingViewModel>();

            builder.Services.AddSingleton<IngredientesList>();
            builder.Services.AddSingleton<IngredientesViewModel>();

            builder.Services.AddTransient<AniadirIngrediente>();
            builder.Services.AddTransient<AniadirIngredienteViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
