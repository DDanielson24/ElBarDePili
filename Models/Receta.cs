using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Models
{
    [Table("Receta")]
    public partial class Receta : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _descripcion;
        public string Imagen {  get; set; }

        [ObservableProperty]
        private TimeSpan _duracion;

        [ObservableProperty]
        private int _dificultad = 0;

        public Receta()
        {
            Id = Guid.NewGuid();
        }

    }
}
