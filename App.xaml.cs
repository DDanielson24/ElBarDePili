using ElBarDePili.Database;
using ElBarDePili.Models;

namespace ElBarDePili
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
