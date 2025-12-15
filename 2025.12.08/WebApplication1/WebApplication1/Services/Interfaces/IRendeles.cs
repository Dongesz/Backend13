using WebApplication1.Models.Dto;

namespace WebApplication1.Services.Interfaces
{
    public interface IRendeles
    {
        Task<ResponseDto> GetAllRendeles();
        Task<ResponseDto> GetAllRendelesWithCard();
        Task<ResponseDto> GetAllRendelesWithFood();
        

    }
}
