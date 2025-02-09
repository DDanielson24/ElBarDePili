using DevExpress.Maui;
using ElBarDePili.ViewModels;
using ElBarDePili.ViewModels.Calculador;
using ElBarDePili.ViewModels.Ingredientes;
using ElBarDePili.ViewModels.Recetas;
using ElBarDePili.Views;
using ElBarDePili.Views.Calculador;
using ElBarDePili.Views.Ingredientes;
using ElBarDePili.Views.Recetas;
using Microsoft.Extensions.Logging;
using ElBarDePili.API.ClassLibraryAPI;

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

            /* === VIEWS === */
            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Calculador>();
            builder.Services.AddSingleton<RecetasList>();
            builder.Services.AddSingleton<IngredientesList>();

            builder.Services.AddTransient<RecetasDetails>();
            builder.Services.AddTransient<RecetasEditing>();
            builder.Services.AddTransient<AniadirIngrediente>();

            /* === VIEWMODELS === */

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<CalculadorViewModel>();
            builder.Services.AddSingleton<RecetasViewModel>();
            builder.Services.AddSingleton<IngredientesViewModel>();
            
            builder.Services.AddTransient<RecetasDetailsViewModel>();
            builder.Services.AddTransient<RecetasEditingViewModel>();
            builder.Services.AddTransient<AniadirIngredienteViewModel>();

            /* === CLASSLIBRARYAPI === */
            
            builder.Services.AddSingleton<ElBarDePiliAPI>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
