using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views.Ingredientes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Ingredientes
{
    public partial class IngredientesViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private ObservableCollection<Ingrediente> _ingredientes = new();

        public IngredientesViewModel(ElBarDePiliDatabase elBarDePiliDatabase) 
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;

            Title = "Ingredientes";

            GetIngredientesAsync();
        }

        private async Task GetIngredientesAsync()
        {
            Ingredientes = new ObservableCollection<Ingrediente>(await _elBarDePiliDatabase.GetIngredientes());
        }

        [RelayCommand]
        private async Task SaveIngredientes()
        {
            await _elBarDePiliDatabase.UpdateAll(Ingredientes);

            await Shell.Current.DisplayAlert("Guardado", "Los ingredientes han sido guardados correctamente.", "De acuerdo");
        }

        [RelayCommand]
        private void GoToAniadirIngrediente()
        {
            Shell.Current.GoToAsync(nameof(AniadirIngrediente), true);
        }
    }
}
