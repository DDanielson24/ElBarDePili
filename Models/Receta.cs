using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ElBarDePili.Models
{
    [Table("Receta")]
    public partial class Receta
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int Duracion { get; set; }
        public int Dificultad { get; set; }
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
