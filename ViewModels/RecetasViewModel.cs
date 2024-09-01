using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Models;
using ElBarDePili.Services;
using ElBarDePili.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    public partial class RecetasViewModel : BaseViewModel
    {
        private DataBaseService _dataBaseService;

        public ObservableCollection<Receta> Recetas { get; set; }

        public RecetasViewModel(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

            Title = "Recetas";
            
            Recetas = new ObservableCollection<Receta>();
            GetRecetas();
        }

        [RelayCommand]
        public void GoToRecetasDetails(Receta receta)
        {
            if (receta == null)
                return;

            Shell.Current.GoToAsync(nameof(RecetasDetails), true,
                new Dictionary<string, object>
                {
                    {"Receta", receta}
                });
        }

        private void GetRecetas()
        {
            Recetas = _dataBaseService.GetRecetas();
        }
    }
}
