using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Models;
using ElBarDePili.Services;
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
        public void ActualizaRecetasBtn()
        {
            Title = "Actualiza Recetas";
            Recetas[0].Dificultad = 10;
            Recetas[1].Dificultad = 10;
            Recetas[2].Dificultad = 10;
        }

        private void GetRecetas()
        {
            Recetas = _dataBaseService.GetRecetas();
        }
    }
}
