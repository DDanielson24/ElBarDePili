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
        }

        [RelayCommand]
        private async Task GetRecetasAsync()
        {
            Recetas = new ObservableCollection<Receta>(await _elBarDePiliDatabase.GetAllWithChildrenAsync<Receta>());
        }

        [RelayCommand]
        private async Task GoToRecetasDetails(Receta receta)
        {
            if (receta == null)
                return;

            var ingredientes = await _elBarDePiliDatabase.GetAllWithChildrenAsync<Ingrediente>();

            await Shell.Current.GoToAsync("Recetas/" + nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", receta}
                });
        }

        [RelayCommand]
        private async Task GoToAniadirReceta()
        {
            await Shell.Current.GoToAsync("Recetas/" + nameof(RecetasEditing), true,
                new Dictionary<string, object>
                {
                    {"Receta", new Receta()}
                });
        }
    }
}
