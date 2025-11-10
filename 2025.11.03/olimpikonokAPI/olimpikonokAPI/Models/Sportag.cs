using System;
using System.Collections.Generic;

namespace olimpikonokAPI.Models;

public partial class Sportag
{
    public int Id { get; set; }

    public string Megnevezes { get; set; } = null!;

    public virtual ICollection<Sportolo> Sportolos { get; set; } = new List<Sportolo>();
}
