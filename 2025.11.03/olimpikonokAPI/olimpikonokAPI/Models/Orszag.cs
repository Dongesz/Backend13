using System;
using System.Collections.Generic;

namespace olimpikonokAPI.Models;

public partial class Orszag
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Fovaros { get; set; } = null!;

    public int Nepesseg { get; set; }

    public virtual ICollection<Sportolo> Sportolos { get; set; } = new List<Sportolo>();
}
