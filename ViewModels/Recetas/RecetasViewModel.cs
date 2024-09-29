using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Database;
using ElBarDePili.Models;
using ElBarDePili.Views;
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
        private void GoToRecetasDetails(Receta receta)
        {
            if (receta == null)
                return;

            Shell.Current.GoToAsync(nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", receta}
                });
        }        
    }
}
