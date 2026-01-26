using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuth.Models;
using RoleBasedAuth.Models.DTOs;

namespace RoleBasedAuth.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public TokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var claimlist = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.FullName.ToString())
            };

            claimlist.AddRange(role.Select(x => new Claim(ClaimTypes.Role, x)));

            var tkenDescription = new SecurityTokenDescriptor()
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimlist),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tkenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
