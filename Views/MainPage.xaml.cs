using ElBarDePili.Views;
using ElBarDePili.ViewModels;

namespace ElBarDePili
{
    public partial class MainPage : ContentPage
    {

        public MainPage(RecetasViewModel recetasViewModel)
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(Recetas)}");
        }
    }

}
