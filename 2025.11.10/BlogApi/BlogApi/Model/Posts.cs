using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApi.Model
{
    public class Posts
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Category { get; set; }
        [Column(TypeName = "text")]
        public string Post{ get; set; }
        public DateTime Regtime { get; set; } = DateTime.Now;
        public DateTime Modtime { get; set; } = DateTime.Now;
        public int BloggerId { get; set; }
        [JsonIgnore]
        public virtual Blogger Blogger { get; set; }

    }
}
