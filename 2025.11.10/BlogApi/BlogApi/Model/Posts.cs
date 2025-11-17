using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Model
{
    public class Posts
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Category { get; set; }
        [Column(TypeName = "text")]
        public string Post{ get; set; }
        public DateTime Regtime { get; set; }
        public DateTime Modtime { get; set; }
        public int BloggerId { get; set; }
        public virtual Blogger Blogger { get; set; }

    }
}
