using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;
using UserRoleApi.Models;
using UserRoleApi.Models.DTOs;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class UserService : IUser
    {
		private readonly DatabaseContext _Context;

        public UserService(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<object> AddNewUser(UserSendDto dto)
        {
			try
			{
				var user = new User
				{
					Id = Guid.NewGuid(),
					Name = dto.Name,
					Email = dto.Email,
					Password = dto.Password,
				};

				var result = new ResultResponseDto();
				if (user == null) return null;

				await _Context.Users.AddAsync(user);
				await _Context.SaveChangesAsync();

				result.message = "sikeres hozzadas";
				result.Result = user;

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

        public async Task<object> GetAllUser()
        {
            try
            {
                var result = new ResultResponseDto();
                result.message = "Sikeres lekerdezes";
                result.Result = await _Context.Users.ToListAsync();
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
                var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    result.message = "User not found";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres lekerdezes";
                result.Result = user;
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

        public async Task<object> UpdateUser(Guid id, UserUpdateDto dto)
        {
            try
            {
                var result = new ResultResponseDto();
                var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    result.message = "User not found";
                    result.Result = null;
                    return result;
                }

                if (!string.IsNullOrWhiteSpace(dto.Name))
                    user.Name = dto.Name;

                if (!string.IsNullOrWhiteSpace(dto.Email))
                    user.Email = dto.Email;

                if (!string.IsNullOrWhiteSpace(dto.Password))
                    user.Password = dto.Password;

                _Context.Users.Update(user);
                var saved = await _Context.SaveChangesAsync();

                if (saved <= 0)
                {
                    result.message = "Nem sikerült frissiteni";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres frissites";
                result.Result = user;
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

        public async Task<object> DeleteUser(Guid id)
        {
            try
            {
                var result = new ResultResponseDto();
                var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    result.message = "User not found";
                    result.Result = null;
                    return result;
                }

                _Context.Users.Remove(user);
                var saved = await _Context.SaveChangesAsync();

                if (saved <= 0)
                {
                    result.message = "Nem sikerült torolni";
                    result.Result = null;
                    return result;
                }

                result.message = "Sikeres torles";
                result.Result = user;
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
