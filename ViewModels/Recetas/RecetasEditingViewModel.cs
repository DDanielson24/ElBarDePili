using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Recetas
{
    [QueryProperty(nameof(Receta), "Receta")]
    public partial class RecetasEditingViewModel : ObservableObject
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private Receta? _receta;

        public RecetasEditingViewModel(ElBarDePiliDatabase elBarDePiliDatabase) 
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
        }

        [RelayCommand]
        private async Task SaveEditing()
        {
            if (Receta == null)
                return;

            await _elBarDePiliDatabase.Update(Receta);

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
