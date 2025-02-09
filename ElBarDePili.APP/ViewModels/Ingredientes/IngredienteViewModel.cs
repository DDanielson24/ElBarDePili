using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Ingredientes
{
    public partial class IngredienteViewModel : ObservableObject
    {
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private bool _disponibilidad;

        public IngredienteViewModel()
        {

        }

    }
}
