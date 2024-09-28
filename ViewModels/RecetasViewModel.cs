using CommunityToolkit.Mvvm.Input;
using ElBarDePili.Models;
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
        public ObservableCollection<Receta> Recetas { get; set; }

        public RecetasViewModel()
        {
            Title = "Recetas";
            
            Recetas = new ObservableCollection<Receta>();
            GetRecetas();
        }

        private void GetRecetas()
        {
            
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
