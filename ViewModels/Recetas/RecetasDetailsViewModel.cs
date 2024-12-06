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
    public partial class RecetasDetailsViewModel : BaseViewModel
    {
        private readonly ElBarDePiliDatabase _elBarDePiliDatabase;

        [ObservableProperty]
        private Receta? _receta;

        public RecetasDetailsViewModel(ElBarDePiliDatabase elBarDePiliDatabase)
        {
            _elBarDePiliDatabase = elBarDePiliDatabase;
        }

        [RelayCommand]
        private void GoToRecetasEditing()
        {
            if (Receta == null)
                return;

            Shell.Current.GoToAsync("Recetas/" + nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", Receta}
                });
        }

        [RelayCommand]
        private async Task DeleteReceta()
        {
            if (Receta == null)
                return;

            await _elBarDePiliDatabase.DeleteWithChildrenAsync<Receta>(Receta);

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
