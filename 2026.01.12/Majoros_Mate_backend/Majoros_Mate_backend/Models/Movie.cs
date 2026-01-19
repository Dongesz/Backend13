using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Majoros_Mate_backend.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int ActorId { get; set; }

    public int FilmTypeId { get; set; }

    [JsonIgnore]
    public virtual Actor Actor { get; set; } = null!;
    [JsonIgnore]
    public virtual FilmType FilmType { get; set; } = null!;
}
