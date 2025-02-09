using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.ViewModels.Ingredientes;
using System.Collections.ObjectModel;

namespace ElBarDePili.ViewModels.Calculador
{
    public partial class CalculadorViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int _duracion;

        [ObservableProperty]
        private int _dificultad;

        [ObservableProperty]
        private ObservableCollection<IngredientesSeleccion> _ingredientes = new();

        public CalculadorViewModel()
        {
            Title = "Calculador recetas";

            GetIngredientesAsync();
        }

        [RelayCommand]
        private async Task GetIngredientesAsync()
        {
            //var ingredientes = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>();
            //var ingredientesDisponibles = ingredientes.Where(i => i.SeDispone).ToList();
            
            //if (ingredientesDisponibles != null)
            //{
            //    foreach(var ingrediente in ingredientesDisponibles)
            //    {
            //        Ingredientes.Add(new IngredientesSeleccion() { Ingrediente = ingrediente, Seleccionado = false });
            //    }
            //}
        }
    }

    public class IngredientesSeleccion
    {
        public IngredienteViewModel Ingrediente { get; set; }
        public bool Seleccionado { get; set; }
    }
}
