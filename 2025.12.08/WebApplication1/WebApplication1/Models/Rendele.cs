using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Rendele
{
    public int Id { get; set; }

    public int? AsztalSzam { get; set; }

    public string? FizetesMod { get; set; }

    public virtual ICollection<Kapcsolo> Kapcsolos { get; set; } = new List<Kapcsolo>();
}
