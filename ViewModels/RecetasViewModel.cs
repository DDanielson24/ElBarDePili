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
    public class RecetasViewModel : BaseViewModel
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

        private void GetRecetas()
        {
            Recetas = _dataBaseService.GetRecetas();
        }
    }
}
