using WebApplication1.Models.Dto;

namespace WebApplication1.Services.Interfaces
{
    public interface IKapcsolo
    {
        Task<object> PostNewRelation(AddRelationDto dto);
    }
}
