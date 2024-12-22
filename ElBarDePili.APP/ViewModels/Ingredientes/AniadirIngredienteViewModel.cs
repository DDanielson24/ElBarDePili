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
            string displayAlertTitle = ""; 
            string displayAlertMessage = "";

            if (_ingredientesViewModel.Ingredientes.Select(x => x.Nombre).ToList().Contains(Ingrediente.Nombre))
            {
                displayAlertTitle = "Error";
                displayAlertMessage = "Estás intentando añadir un ingrediente ya existente";
            }
            else
            {
                try
                {
                    await _elBarDePiliDatabase.SaveWithChildrenAsync(Ingrediente);
                    _ingredientesViewModel.Ingredientes.Add(Ingrediente);

                    displayAlertTitle = "Guardado";
                    displayAlertMessage = "Los ingredientes han sido guardados correctamente.";
                }
                catch
                {
                    displayAlertTitle = "Error";
                    displayAlertMessage = "Ha surgido un error al guardar el ingrediente";
                }
                finally
                {
                    await Shell.Current.Navigation.PopAsync();
                }
            }
            
            await Shell.Current.DisplayAlert(displayAlertTitle, displayAlertMessage, "De acuerdo");
        }
    }
}
