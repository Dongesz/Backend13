using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using RoleBasedAuth.Data;
using RoleBasedAuth.Models;
using RoleBasedAuth.Models.DTOs;

namespace RoleBasedAuth.Services
{
    public class Auth : IAuth
    {
		private readonly AppDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        public Auth(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenGenerator tokenGenerator = null)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<object> AssignRole(AssignRoleDto dto)
        {
            try
            {
                var user = _context.ApplicationUsers.FirstOrDefault(x => x.NormalizedUserName == dto.UserName);
                if (user != null)
                {
                    if (!_roleManager.RoleExistsAsync(dto.RoleName).GetAwaiter().GetResult())
                    {
                        _roleManager.CreateAsync(new IdentityRole(dto.RoleName)).GetAwaiter().GetResult();
                    }
                    await _userManager.AddToRoleAsync(user, dto.RoleName);
                    return new { result = user, message = "sikeres hozzarendeles!" };
                }
                return new { result = "", message = "sikertelen hozzarendeles!" };
            }
            catch (Exception ex)
            {

                return new { result = "", message = ex.Message };
                
            }
          
        }

        public async Task<object> Login(LoginDto dto)
        {
            try
            {
                var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.NormalizedUserName == dto.UserName.ToUpper());
                bool isValid = await _userManager.CheckPasswordAsync(user, dto.Password);

                if (isValid)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var jwtToken = _tokenGenerator.GenerateToken(user, roles);

                    return new { result = new {user.UserName, user.Email}, message = "sikeres login!", token = jwtToken};
             
                }
                return new { result = "", message = "sikertelen login!" };

            }
            catch (Exception ex)
            {

                return new { result = "", message = ex.Message };
              
            }
        }

        public async Task<object> Register(RegisterRequestDto registerRequestDto)
        {
			try
			{
                var user = new ApplicationUser
                {
                    UserName = registerRequestDto.UserName,
                    FullName = registerRequestDto.FullName,
                    Email = registerRequestDto.Email
                };
                var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

                if (result.Succeeded)
                {
                    var userReturn = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == registerRequestDto.UserName);

                    return new { result = userReturn, message = "Sikeres Regisztracio!" };
                }

                return new { result = "", message = result.Errors.FirstOrDefault().Description };
            }
			catch (Exception ex)
            {

                return new { result = "", message = ex.Message };

            }
        }
    }
}
