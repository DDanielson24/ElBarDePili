using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Maui.DataForm;
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
    public partial class Ingrediente : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [ObservableProperty]
        [property: DataFormDisplayOptions(LabelPosition = DataFormLabelPosition.Top)]
        private string _nombre;

        [ObservableProperty]
        [property: DataFormDisplayOptions(LabelText = "Disponibilidad", LabelWidth = "100")]
        private bool _seDispone;

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
