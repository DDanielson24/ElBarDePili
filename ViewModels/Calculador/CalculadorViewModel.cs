using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Calculador
{
    public partial class CalculadorViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private int _duracion;

        [ObservableProperty]
        private int _dificultad;

        [ObservableProperty]
        private ObservableCollection<IngredientesSeleccion> _ingredientes = new();

        public CalculadorViewModel(ElBarDePiliDatabase elBarDePiliDatabase)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
            Title = "Calculador recetas";

            GetIngredientesAsync();
        }

        [RelayCommand]
        private async Task GetIngredientesAsync()
        {
            var ingredientes = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>();
            var ingredientesDisponibles = ingredientes.Where(i => i.SeDispone).ToList();
            
            if (ingredientesDisponibles != null)
            {
                foreach(var ingrediente in ingredientesDisponibles)
                {
                    Ingredientes.Add(new IngredientesSeleccion() { Ingrediente = ingrediente, Seleccionado = false });
                }
            }
        }
    }

    public class IngredientesSeleccion
    {
        public Ingrediente Ingrediente { get; set; }
        public bool Seleccionado { get; set; }
    }
}
