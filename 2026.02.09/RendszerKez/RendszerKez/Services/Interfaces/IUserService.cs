using System.Security.Claims;
using RendszerKez.Dtos;
using RendszerKez.Models;

namespace RendszerKez.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        Task<User?> GetUserAsync(ClaimsPrincipal user);

    }
}
