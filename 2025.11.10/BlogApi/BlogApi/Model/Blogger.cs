using System.ComponentModel.DataAnnotations;

namespace BlogApi.Model
{
    public class Blogger
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Phone {  get; set; }
        public DateTime RegTime { get; set; } = DateTime.Now;
        public DateTime ModTime { get; set; } = DateTime.Now;
        public virtual ICollection<Posts> Posts { get; set; } = new List<Posts>();
    }
}
