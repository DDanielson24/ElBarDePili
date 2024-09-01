using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Models
{
    public partial class Receta : ObservableObject
    {
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _nombre;
        public string Descripcion { get; set; }
        public string Imagen {  get; set; }
        public TimeSpan Duracion { get; set; }

        [ObservableProperty]
        private int _dificultad = 0;

        public Receta()
        {
            Id = Guid.NewGuid();
        }

    }
}
