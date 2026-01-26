using Microsoft.AspNetCore.Identity;

namespace RoleBasedAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
