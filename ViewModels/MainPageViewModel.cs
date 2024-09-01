using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel() { }

        [RelayCommand]
        public void GoToRecetasSection() 
        {
            Shell.Current.GoToAsync(nameof(Recetas));
        }

        [RelayCommand]
        public void GoToIngredientesSection() 
        {
            Application.Current?.MainPage?.DisplayAlert("Próximamente", "Esta sección aún no está implementada.", "De acuerdo");
        }

        [RelayCommand]
        public void GoToConfiguracionSection() 
        {
            Application.Current?.MainPage?.DisplayAlert("Próximamente", "Esta sección aún no está implementada.", "De acuerdo");
        }
    }
}
