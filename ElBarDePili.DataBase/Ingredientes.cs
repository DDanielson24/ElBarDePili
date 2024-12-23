using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ElBarDePili.DataBase;

public partial class Ingredientes
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Disponibilidad { get; set; }

    [JsonIgnore]
    public virtual ICollection<RecetasIngredientes> RecetasIngredientes { get; set; } = new List<RecetasIngredientes>();
}
