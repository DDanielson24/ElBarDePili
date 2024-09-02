using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Models;
using ElBarDePili.Services;
using ElBarDePili.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    [QueryProperty(nameof(Receta), "Receta")]
    public partial class RecetasEditingViewModel : ObservableObject
    {
        private DataBaseService _dataBaseService;

        [ObservableProperty]
        private Receta? _receta;

        public RecetasEditingViewModel(DataBaseService dataBaseService) 
        {
            _dataBaseService = dataBaseService;
        }

        [RelayCommand]
        private void SaveEditing()
        {
            if (Receta == null || _dataBaseService == null)
                return;

            _dataBaseService.SaveReceta(Receta);

            Shell.Current.Navigation.PopAsync();
        }
    }
}
