using UserRoleApi.Models.DTOs;

namespace UserRoleApi.Services.IServices
{
    public interface IRoles
    {
        Task<object> AddNewRole(RolesSendDto dto);
        Task<object> GetAllRoles();
        Task<object> GetById(Guid id);
        Task<object> UpdateRole(Guid id, RolesUpdateDto dto);
        Task<object> DeleteRole(Guid id);
    }
}
