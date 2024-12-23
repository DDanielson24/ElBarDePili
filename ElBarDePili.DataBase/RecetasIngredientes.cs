using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ElBarDePili.DataBase;

public partial class RecetasIngredientes
{
    public Guid Id { get; set; }

    public Guid Idreceta { get; set; }

    public Guid Idingrediente { get; set; }

    [JsonIgnore]
    public virtual Ingredientes IdingredienteNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Recetas IdrecetaNavigation { get; set; } = null!;
}
