namespace BlogApi.Model
{
    public class Blogger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegTime{ get; set; }
    }
}
