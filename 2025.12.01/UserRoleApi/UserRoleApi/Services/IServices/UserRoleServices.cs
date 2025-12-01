using Microsoft.EntityFrameworkCore;
using UserRoleApi.Models;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class UserRolesService : IUserRoles
    {
        private readonly DatabaseContext _Context;

        public UserRolesService(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<object> AddNewUserRole(UserRoleSendDto dto)
        {
            try
            {
                var result = new ResultResponseDto();

                var user = await _Context.Users.FindAsync(dto.UserId);
                var role = await _Context.Roles.FindAsync(dto.RoleId);

                if (user == null || role == null)
                {
                    result.message = "User vagy Role nem található";
                    result.Result = null;
                    return result;
                }

                var existing = await _Context.UserRoles
                    .FirstOrDefaultAsync(x => x.UserId == dto.UserId && x.RoleId == dto.RoleId);

                if (existing != null)
                {
                    result.message = "Ez a kapcsolat már létezik";
                    result.Result = existing;
                    return result;
                }

                var userRole = new UserRole
                {
                    UserId = dto.UserId,
                    RoleId = dto.RoleId
                };

                await _Context.UserRoles.AddAsync(userRole);
                await _Context.SaveChangesAsync();

                result.message = "Sikeres kapcsolatteremtés";
                result.Result = userRole;
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

        public async Task<object> GetAllUserRoles()
        {
            try
            {
                var result = new ResultResponseDto();
                result.message = "Sikeres lekérdezés";

                result.Result = await _Context.UserRoles
                    .Include(x => x.User)
                    .Include(x => x.Roles)
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

                var items = await _Context.UserRoles
                    .Include(x => x.User)
                    .Include(x => x.Roles)
                    .Where(x => x.UserId == id)
                    .ToListAsync();

                if (!items.Any())
                {
                    result.message = "Ehhez a UserId-hoz nincs szerep";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres lekérdezés";
                result.Result = items;
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

        public async Task<object> UpdateUserRole(Guid id, UserRolesUpdateDto dto)
        {
            try
            {
                var result = new ResultResponseDto();

                // update is userId alapján → ez normál kapcsolótáblánál ritka, de követem a mintád
                var connection = await _Context.UserRoles
                    .FirstOrDefaultAsync(x => x.UserId == id);

                if (connection == null)
                {
                    result.message = "Kapcsolat nem található";
                    result.Result = null;
                    return result;
                }

                connection.UserId = dto.UserId;
                connection.RoleId = dto.RoleId;

                _Context.UserRoles.Update(connection);
                await _Context.SaveChangesAsync();

                result.message = "Sikeres frissítés";
                result.Result = connection;
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

        public async Task<object> DeleteUserRole(Guid id)
        {
            try
            {
                var result = new ResultResponseDto();

                var connection = await _Context.UserRoles
                    .FirstOrDefaultAsync(x => x.UserId == id);

                if (connection == null)
                {
                    result.message = "Kapcsolat nem található";
                    result.Result = null;
                    return result;
                }

                _Context.UserRoles.Remove(connection);
                await _Context.SaveChangesAsync();

                result.message = "Sikeres törlés";
                result.Result = connection;
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
