using System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleApi.Models
{
    public class Roles
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        public DateTime RegTime { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
