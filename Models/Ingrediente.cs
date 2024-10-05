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
    public partial class Ingrediente : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private bool _seDispone;

        public Ingrediente()
        {
            Id = Guid.NewGuid();
            Nombre = String.Empty;
            SeDispone = false;
        }
    }
}
