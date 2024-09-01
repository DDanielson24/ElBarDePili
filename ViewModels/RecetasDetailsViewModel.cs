using CommunityToolkit.Mvvm.ComponentModel;
using ElBarDePili.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels
{
    [QueryProperty(nameof(Receta), "Receta")]
    public partial class RecetasDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Receta _receta;

        public RecetasDetailsViewModel() {}
    }
}
