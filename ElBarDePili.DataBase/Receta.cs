using System;
using System.Collections.Generic;

namespace ElBarDePili.DataBase;

public partial class Receta
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public int Duracion { get; set; }

    public int Dificultad { get; set; }
}
