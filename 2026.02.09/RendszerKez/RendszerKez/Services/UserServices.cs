namespace RendszerKez.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using RendszerKez.Dtos;
    using RendszerKez.Models;
    using RendszerKez.Services.Interfaces;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly RendszerkezContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(RendszerkezContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(x => x.Email == dto.Email))
                return false;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<User?> GetUserAsync(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
                return null;

            if (!int.TryParse(userIdClaim, out var userId))
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
