using System.Text.Json.Serialization;

namespace Majoros_Máté_backend.Models.Dtos
{
    public class BookSendDto
    {
        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}
