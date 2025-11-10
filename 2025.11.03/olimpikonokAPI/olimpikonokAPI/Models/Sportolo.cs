using System;
using System.Collections.Generic;

namespace olimpikonokAPI.Models;

public partial class Sportolo
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public bool Neme { get; set; }

    public DateTime SzulDatum { get; set; }

    public int SportagId { get; set; }

    public int Ermek { get; set; }

    public int OrszagId { get; set; }

    public byte[] IndexKep { get; set; } = null!;

    public byte[] Kep { get; set; } = null!;

    public virtual Orszag Orszag { get; set; } = null!;

    public virtual Sportag Sportag { get; set; } = null!;
}
