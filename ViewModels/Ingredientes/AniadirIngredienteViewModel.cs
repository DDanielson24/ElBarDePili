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
        private readonly IngredientesViewModel _ingredientesViewModel;

        [ObservableProperty]
        private Ingrediente _ingrediente;

        public AniadirIngredienteViewModel(ElBarDePiliDatabase elBarDePiliDatabase, IngredientesViewModel ingredientesViewModel)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
            _ingredientesViewModel = ingredientesViewModel;

            _ingrediente = new Ingrediente();
        }

        [RelayCommand]
        private async Task SaveIngrediente()
        {
            if (_ingredientesViewModel.Ingredientes.Select(x => x.Nombre).ToList().Contains(Ingrediente.Nombre))
            {
                await Shell.Current.DisplayAlert("Error", "Estás intentando añadir un ingrediente ya existente", "De acuerdo");
                return;
            }

            try
            {
                await _elBarDePiliDatabase.Add(Ingrediente);
                _ingredientesViewModel.Ingredientes.Add(Ingrediente);

                await Shell.Current.DisplayAlert("Guardado", "Los ingredientes han sido guardados correctamente.", "De acuerdo");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Ha surgido un error al guardar el ingrediente", "De acuerdo");
            }
            finally
            {
                await Shell.Current.Navigation.PopAsync();
            }

        }
    }
}
