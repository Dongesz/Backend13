using UserRoleApi.Models.DTOs;

namespace UserRoleApi.Services.IServices
{
    public interface IUser
    {
        Task<object> AddNewUser(UserSendDto dto);
        Task<object> GetAllUser();
        Task<object> GetById(Guid id);
        Task<object> UpdateUser(Guid id, UserUpdateDto dto);
        Task<object> DeleteUser(Guid id);
    }
}
