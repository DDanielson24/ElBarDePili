using ElBarDePili.Views;

namespace ElBarDePili
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Recetas), typeof(Recetas));
        }
    }
}
