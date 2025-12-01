namespace UserRoleApi.Models
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Roles Roles { get; set; }
    }
}
