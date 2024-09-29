using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Ingredientes
{
    public partial class AniadirIngredienteViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private Ingrediente _ingrediente;

        public AniadirIngredienteViewModel(ElBarDePiliDatabase elBarDePiliDatabase)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;

            _ingrediente = new Ingrediente();
        }

        [RelayCommand]
        private async Task SaveIngrediente()
        {
            await _elBarDePiliDatabase.Add(Ingrediente);

            await Shell.Current.Navigation.PopAsync();

            await Shell.Current.DisplayAlert("Guardado", "Los ingredientes han sido guardados correctamente.", "De acuerdo");

        }
    }
}
