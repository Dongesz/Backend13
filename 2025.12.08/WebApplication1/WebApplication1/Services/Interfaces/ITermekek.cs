using WebApplication1.Models.Dto;

namespace WebApplication1.Services.Interfaces
{
    public interface ITermekek
    {
        Task<ResponseDto> GetAllTermek();
        Task<ResponseDto> GetLegtobbTermekFogyott();

    }
}
