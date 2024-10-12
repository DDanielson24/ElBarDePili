using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Models
{
    [Table("Ingrediente")]
    public partial class Ingrediente
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool SeDispone { get; set; }
        [ManyToMany(typeof(RecetaIngrediente), CascadeOperations = CascadeOperation.All)]
        public List<Receta>? Recetas { get; set; }

        public Ingrediente()
        {
            Id = Guid.NewGuid();
            Nombre = String.Empty;
            SeDispone = false;
        }
    }
}
