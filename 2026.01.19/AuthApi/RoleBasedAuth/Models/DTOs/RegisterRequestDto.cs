namespace RoleBasedAuth.Models.DTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public string? FullName { get; set; }
    }
}
