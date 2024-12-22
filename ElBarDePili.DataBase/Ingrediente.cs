using System;
using System.Collections.Generic;

namespace ElBarDePili.DataBase;

public partial class Ingrediente
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Disponibilidad { get; set; }
}
