﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        public MainPageViewModel(ElBarDePiliDatabase elBarDePiliDatabase) 
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
        }

        [RelayCommand]
        public void GoToRecetasSection() 
        {
            Shell.Current.GoToAsync(nameof(Recetas));
        }

        [RelayCommand]
        public void GoToIngredientesSection() 
        {
            Shell.Current.GoToAsync(nameof(Ingredientes));
        }

        [RelayCommand]
        public void GoToConfiguracionSection() 
        {
            Shell.Current.DisplayAlert("Próximamente", "Esta sección aún no está implementada.", "De acuerdo");
        }
    }
}