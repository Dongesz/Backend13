using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Model.DTOs
{
    public class AddPostDto
    {
        public string Category { get; set; }
        public string Post { get; set; }
        public int BloggerId { get; set; }

    }
}
