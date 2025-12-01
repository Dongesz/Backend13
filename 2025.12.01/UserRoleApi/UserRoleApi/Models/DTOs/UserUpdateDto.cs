using System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleApi.Models.DTOs
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
