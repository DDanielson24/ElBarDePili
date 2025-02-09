using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Views.Ingredientes;
using System.Collections.ObjectModel;

namespace ElBarDePili.ViewModels.Ingredientes
{
    public partial class IngredientesViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<IngredienteViewModel> _ingredientes = new();

        public IngredientesViewModel() 
        {
            Title = "Ingredientes";
        }

        [RelayCommand]
        private async Task GetIngredientesAsync()
        {
            //Ingredientes = new ObservableCollection<Ingrediente>((await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>()).OrderBy(x => x.Nombre));
        }

        [RelayCommand]
        private async Task SaveIngredientes()
        {
            //foreach(var ingrediente in Ingredientes)
            //{
            //    await _elBarDePiliDatabase.UpdateWithChildrenAsync<Ingrediente>(ingrediente);
            //}

            //await Shell.Current.DisplayAlert("Guardado", "Los ingredientes han sido guardados correctamente.", "De acuerdo");
        }

        [RelayCommand]
        private void GoToAniadirIngrediente()
        {
            Shell.Current.GoToAsync("Ingredientes/" + nameof(AniadirIngrediente), true);
        }

        [RelayCommand]
        private async Task DeleteIngrediente(IngredienteViewModel ingrediente)
        {
            //await _elBarDePiliDatabase.DeleteWithChildrenAsync(ingrediente);
            //Ingredientes.Remove(ingrediente);
        }
    }
}
