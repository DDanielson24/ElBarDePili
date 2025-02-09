using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.ViewModels.Recetas
{
    public partial class RecetaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Guid _id;
        
        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _descripcion;

        [ObservableProperty]
        private string _imagen;

        [ObservableProperty]
        private int _duracion;

        [ObservableProperty]
        private int _dificultad;

        public RecetaViewModel()
        {
            
        }
    }
}
