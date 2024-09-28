using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.Models
{
    [Table("Ingrediente")]
    public class Ingrediente : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public Ingrediente()
        {
            Id = Guid.NewGuid();
        }
    }
}
