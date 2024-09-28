using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Models;
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
        [ObservableProperty]
        private Receta? _receta;

        public RecetasEditingViewModel() 
        {
        }

        [RelayCommand]
        private void SaveEditing()
        {
            if (Receta == null)
                return;

            Shell.Current.Navigation.PopAsync();
        }
    }
}
