using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class KapcsoloServices : IKapcsolo
    {
        private readonly DatabaseContext _context;
        private readonly ResponseDto _responseDto;

        public KapcsoloServices(DatabaseContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
            
        }
        public async Task<object> PostNewRelation(AddRelationDto dto)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
