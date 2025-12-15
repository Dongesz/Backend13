using WebApplication1.Models.Dto;

namespace WebApplication1.Services.Interfaces
{
    public interface IRendeles
    {
        Task<ResponseDto> GetAllRendeles();
        Task<ResponseDto> GetAllRendelesWithCard();
        Task<ResponseDto> GetAllRendelesWithFood();
        Task<ResponseDto> GetRendelesTetelek();

        Task<ResponseDto> GetRendelesenkentTetelek();
        Task<ResponseDto> GetTermekekRendelesenkent();
        Task<ResponseDto> GetKolasRendelesek();
        Task<ResponseDto> GetRendelesekTetelszama();
        Task<ResponseDto> GetKettesRendelesOsszertek();
        Task<ResponseDto> GetRendelesekOsszerteke();
        Task<ResponseDto> GetLegdragabbRendeles();
        Task<ResponseDto> GetAsztalokHanyszorRendeltek();


    }
}
