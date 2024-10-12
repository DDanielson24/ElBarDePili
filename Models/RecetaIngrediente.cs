using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ElBarDePili.Models
{
    [Table("RecetaIngrediente")]
    public class RecetaIngrediente
    {
        [ForeignKey(typeof(Receta))]
        public Guid RecetaId { get; set; }
        [ForeignKey(typeof(Ingrediente))]
        public Guid IngredienteId { get; set; }
    }
}
