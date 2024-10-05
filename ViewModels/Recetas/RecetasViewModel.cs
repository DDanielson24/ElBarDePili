using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views.Recetas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Recetas
{
    public partial class RecetasViewModel : BaseViewModel
    {        
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private ObservableCollection<Receta> _recetas = new ();

        public RecetasViewModel(ElBarDePiliDatabase elBarDePiliDatabase)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
            Title = "Recetas";

            GetRecetasAsync();
        }

        private async Task GetRecetasAsync()
        {
            Recetas = new ObservableCollection<Receta>(await _elBarDePiliDatabase.GetRecetas());
        }

        [RelayCommand]
        private async void GoToRecetasDetails(Receta receta)
        {
            if (receta == null)
                return;

            var ingredientes = (await _elBarDePiliDatabase.GetIngredientes()).ToList();

            List<IngredientesReceta> ingredientesReceta = new();
            foreach (var ingrediente in ingredientes)
            {
                ingredientesReceta.Add(new IngredientesReceta()
                {
                    Ingrediente = ingrediente,
                    FormaParteReceta = false
                });
            }

            Shell.Current.GoToAsync(nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", receta},
                    {"IngredientesReceta", ingredientesReceta}
                });
        }

        [RelayCommand]
        private async void GoToAniadirReceta()
        {
            var ingredientes = (await _elBarDePiliDatabase.GetIngredientes()).ToList();

            List<IngredientesReceta> ingredientesReceta = new ();
            foreach (var ingrediente in ingredientes)
            {
                ingredientesReceta.Add(new IngredientesReceta()
                {
                    Ingrediente = ingrediente,
                    FormaParteReceta = false
                });   
            }

            Shell.Current.GoToAsync(nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", new Receta()},
                    {"IngredientesReceta", ingredientesReceta}
                });
        }
    }
}
