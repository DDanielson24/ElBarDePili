using System;
using System.Collections.Generic;

namespace ElBarDePili.DataBase;

public partial class RecetasIngrediente
{
    public Guid Id { get; set; }

    public Guid Idreceta { get; set; }

    public Guid Idingrediente { get; set; }
}
