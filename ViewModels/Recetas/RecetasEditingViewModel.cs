using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views;
using ElBarDePili.Views.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Recetas
{
    [QueryProperty(nameof(Receta), "Receta")]
    [QueryProperty(nameof(IngredientesReceta), "IngredientesReceta")]
    public partial class RecetasEditingViewModel : ObservableObject
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;
        private readonly RecetasViewModel _recetasViewModel;

        [ObservableProperty]
        private Receta? _receta = new();

        [ObservableProperty]
        private List<IngredientesReceta> _ingredientesReceta = new();

        public RecetasEditingViewModel(ElBarDePiliDatabase elBarDePiliDatabase, RecetasViewModel recetasViewModel) 
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
            _recetasViewModel = recetasViewModel;
        }

        [RelayCommand]
        private async Task SaveEditing()
        {
            if (Receta == null)
                return;

            var recetas = await _elBarDePiliDatabase.GetRecetas();

            if (recetas.Where(x => x.Id.Equals(Receta.Id)).Any())
            {
                await _elBarDePiliDatabase.Update(Receta);

                var ingredientesDeRecetaDB = (await _elBarDePiliDatabase.GetIngredientesRecetas()).Where(x => x.RecetaId == Receta.Id).ToList();

                foreach (var ingredienteReceta in IngredientesReceta)
                {
                    if (ingredienteReceta.FormaParteReceta && !ingredientesDeRecetaDB.Any(x => x.Id == ingredienteReceta.Ingrediente.Id))
                    {
                        await _elBarDePiliDatabase.Add(new IngredientesRecetas()
                        {
                            Id = Guid.NewGuid(),
                            RecetaId = Receta.Id,
                            IngredienteId = ingredienteReceta.Ingrediente.Id
                        });
                    }
                    else if (!ingredienteReceta.FormaParteReceta && ingredientesDeRecetaDB.Any(x => x.Id == ingredienteReceta.Ingrediente.Id))
                    {
                        await _elBarDePiliDatabase.Delete(ingredientesDeRecetaDB.First(x => x.IngredienteId == ingredienteReceta.Ingrediente.Id));
                    }
                }
            }
            else
            {
                await _elBarDePiliDatabase.Add(Receta);
                _recetasViewModel.Recetas.Add(Receta);

                List<IngredientesRecetas> ingredientesRecetas = new();
                foreach(var ingredienteReceta in IngredientesReceta.Where(x => x.FormaParteReceta))
                {
                    ingredientesRecetas.Add(new IngredientesRecetas()
                    {
                        Id = Guid.NewGuid(),
                        RecetaId = Receta.Id,
                        IngredienteId = ingredienteReceta.Ingrediente.Id
                    });
                }

                await _elBarDePiliDatabase.AddAll(ingredientesRecetas);
            }

            var editingPage = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 1];
            var detailsPage = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2];

            Shell.Current.GoToAsync(nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", Receta},
                    {"IngredientesReceta", IngredientesReceta}
                });

            if (editingPage != null) Shell.Current.Navigation.RemovePage(editingPage);
            if (detailsPage != null) Shell.Current.Navigation.RemovePage(detailsPage);
        }
    }
}
