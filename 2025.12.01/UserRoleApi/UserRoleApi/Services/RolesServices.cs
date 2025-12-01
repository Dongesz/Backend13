using Microsoft.EntityFrameworkCore;
using UserRoleApi.Models;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class RolesService : IRoles
    {
        private readonly DatabaseContext _Context;

        public RolesService(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<object> AddNewRole(RolesSendDto dto)
        {
            try
            {
                var role = new Roles
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    RegTime = DateTime.UtcNow
                };

                var result = new ResultResponseDto();

                await _Context.Roles.AddAsync(role);
                var saved = await _Context.SaveChangesAsync();

                if (saved <= 0)
                {
                    result.message = "Nem sikerült menteni az adatbázisba";
                    result.Result = null;
                    return result;
                }

                result.message = "sikeres hozzadas";
                result.Result = role;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.Result = null;
                return result;
            }
        }

        public async Task<object> GetAllRoles()
        {
            try
            {
                var result = new ResultResponseDto();
                result.message = "Sikeres lekerdezes";
                result.Result = await _Context.Roles
                                   .Include(r => r.UserRoles)
                                   .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.Result = null;
                return result;
            }
        }

        public async Task<object> GetById(Guid id)
        {
            try
            {
                var result = new ResultResponseDto();
                var role = await _Context.Roles
                              .Include(r => r.UserRoles)
                              .FirstOrDefaultAsync(r => r.Id == id);

                if (role == null)
                {
                    result.message = "Role not found";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres lekerdezes";
                result.Result = role;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.Result = null;
                return result;
            }
        }

        public async Task<object> UpdateRole(Guid id, RolesUpdateDto dto)
        {
            try
            {
                var result = new ResultResponseDto();
                var role = await _Context.Roles.FirstOrDefaultAsync(r => r.Id == id);

                if (role == null)
                {
                    result.message = "Role not found";
                    result.Result = null;
                    return result;
                }

                if (!string.IsNullOrWhiteSpace(dto.Name))
                    role.Name = dto.Name;

                _Context.Roles.Update(role);
                var saved = await _Context.SaveChangesAsync();

                if (saved <= 0)
                {
                    result.message = "Nem sikerült frissiteni";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres frissites";
                result.Result = role;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.Result = null;
                return result;
            }
        }

        public async Task<object> DeleteRole(Guid id)
        {
            try
            {
                var result = new ResultResponseDto();
                var role = await _Context.Roles.FirstOrDefaultAsync(r => r.Id == id);

                if (role == null)
                {
                    result.message = "Role not found";
                    result.Result = null;
                    return result;
                }

                _Context.Roles.Remove(role);
                var saved = await _Context.SaveChangesAsync();

                if (saved <= 0)
                {
                    result.message = "Nem sikerült torolni";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres torles";
                result.Result = role;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.Result = null;
                return result;
            }
        }
    }
}
