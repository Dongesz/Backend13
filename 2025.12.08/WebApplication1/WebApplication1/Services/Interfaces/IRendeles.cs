using WebApplication1.Models.Dto;

namespace WebApplication1.Services.Interfaces
{
    public interface IRendeles
    {
        Task<ResponseDto> GetAllRendeles();
    }
}
