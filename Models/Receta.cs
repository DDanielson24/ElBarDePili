using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

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

        [ObservableProperty]
        private string _imagen;

        [ObservableProperty]
        private int _duracion;

        [ObservableProperty]
        private int _dificultad;

        public Receta()
        {
            Id = Guid.NewGuid();
            Nombre = String.Empty;
            Descripcion = String.Empty;
            Imagen = String.Empty;
            Duracion = 0;
            Dificultad = 0;
        }

    }
}
