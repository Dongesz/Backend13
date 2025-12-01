namespace UserRoleApi.Models.DTOs
{
    public class UserRolesUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
