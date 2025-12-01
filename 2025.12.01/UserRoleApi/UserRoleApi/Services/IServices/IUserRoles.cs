using UserRoleApi.Models.DTOs;

namespace UserRoleApi.Services.IServices
{
    public interface IUserRoles
    {
        Task<object> AddNewUserRole(UserRoleSendDto dto);
        Task<object> GetAllUserRoles();
        Task<object> GetById(Guid id);
        Task<object> UpdateUserRole(Guid id, UserRolesUpdateDto dto);
        Task<object> DeleteUserRole(Guid id);
    }
}
