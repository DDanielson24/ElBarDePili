using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Models
{
    [Table("IngredientesRecetas")]
    public class IngredientesRecetas
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public Guid RecetaId { get; set; }
        public Guid IngredienteId { get; set; } 
    }

    public class IngredientesReceta
    {
        public Ingrediente Ingrediente { get; set; }
        public bool FormaParteReceta { get; set; }
    }
}
