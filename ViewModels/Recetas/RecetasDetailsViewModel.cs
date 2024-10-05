﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class RecetasDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Receta? _receta;

        [ObservableProperty]
        private List<IngredientesReceta> _ingredientesReceta = new();

        public RecetasDetailsViewModel() {}

        [RelayCommand]
        private void GoToRecetasEditing()
        {
            if (Receta == null)
                return;

            Shell.Current.GoToAsync(nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", Receta},
                    {"IngredientesReceta", IngredientesReceta}
                });
        }
    }
}
