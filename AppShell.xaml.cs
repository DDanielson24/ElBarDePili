using ElBarDePili.Views;
using ElBarDePili.Views.Ingredientes;
using ElBarDePili.Views.Recetas;
using ElBarDePili.Views.Calculador;

namespace ElBarDePili
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Calculador), typeof(Calculador));

            //Routing.RegisterRoute("Recetas/" + nameof(RecetasList), typeof(RecetasList));
            Routing.RegisterRoute("Recetas/" + nameof(RecetasDetails), typeof(RecetasDetails));
            Routing.RegisterRoute("Recetas/" + nameof(RecetasEditing), typeof(RecetasEditing));

            //Routing.RegisterRoute("Ingredientes/" + nameof(IngredientesList), typeof(IngredientesList));
            Routing.RegisterRoute("Ingredientes/" + nameof(AniadirIngrediente), typeof(AniadirIngrediente));
        }
    }
}
