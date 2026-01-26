using RoleBasedAuth.Models;

namespace RoleBasedAuth.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> role);
    }
}
