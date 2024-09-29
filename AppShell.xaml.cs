using ElBarDePili.Views;
using ElBarDePili.Views.Ingredientes;
using ElBarDePili.Views.Recetas;

namespace ElBarDePili
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RecetasList), typeof(RecetasList));
            Routing.RegisterRoute(nameof(RecetasDetails), typeof(RecetasDetails));
            Routing.RegisterRoute(nameof(RecetasEditing), typeof(RecetasEditing));

            Routing.RegisterRoute(nameof(IngredientesList), typeof(IngredientesList));
            Routing.RegisterRoute(nameof(AniadirIngrediente), typeof(AniadirIngrediente));
        }
    }
}
