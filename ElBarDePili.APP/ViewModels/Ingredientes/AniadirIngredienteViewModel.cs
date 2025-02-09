using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ElBarDePili.ViewModels.Ingredientes
{
    public partial class AniadirIngredienteViewModel : BaseViewModel
    {
        private readonly IngredientesViewModel _ingredientesViewModel;

        [ObservableProperty]
        private IngredienteViewModel _ingrediente;

        public AniadirIngredienteViewModel(IngredientesViewModel ingredientesViewModel)
        {
            _ingredientesViewModel = ingredientesViewModel;

            _ingrediente = new IngredienteViewModel();
        }

        [RelayCommand]
        private async Task SaveIngrediente()
        {
            //string displayAlertTitle = ""; 
            //string displayAlertMessage = "";

            //if (_ingredientesViewModel.Ingredientes.Select(x => x.Nombre).ToList().Contains(Ingrediente.Nombre))
            //{
            //    displayAlertTitle = "Error";
            //    displayAlertMessage = "Estás intentando añadir un ingrediente ya existente";
            //}
            //else
            //{
            //    try
            //    {
            //        await _elBarDePiliDatabase.SaveWithChildrenAsync(Ingrediente);
            //        _ingredientesViewModel.Ingredientes.Add(Ingrediente);

            //        displayAlertTitle = "Guardado";
            //        displayAlertMessage = "Los ingredientes han sido guardados correctamente.";
            //    }
            //    catch
            //    {
            //        displayAlertTitle = "Error";
            //        displayAlertMessage = "Ha surgido un error al guardar el ingrediente";
            //    }
            //    finally
            //    {
            //        await Shell.Current.Navigation.PopAsync();
            //    }
            //}
            
            //await Shell.Current.DisplayAlert(displayAlertTitle, displayAlertMessage, "De acuerdo");
        }
    }
}
