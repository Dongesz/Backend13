namespace Majoros_Mate_backend.Controllers
{
    public class MoviePostDto
    {
        public string Title { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int ActorId { get; set; }

        public int FilmTypeId { get; set; }
    }
}
