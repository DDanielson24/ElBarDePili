using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Maui.DataForm;
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
        [property: DataFormDisplayOptions(LabelText = "Nombre")]
        private string _nombre;

        [ObservableProperty]
        private string _descripcion;

        [ObservableProperty]
        [property: DataFormDisplayOptions(IsVisible = false)]
        private string _imagen;

        [ObservableProperty]
        private int _duracion;

        [ObservableProperty]
        private int _dificultad;

        [ManyToMany(typeof(RecetaIngrediente), CascadeOperations = CascadeOperation.All)]
        public List<Ingrediente>? Ingredientes { get; set; }

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
