using Org.BouncyCastle.Asn1.Ocsp;
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
        public async Task<object> PostNewRelation(AddRelationDto addRelationDto)
        {
            try
            {
                var relation = new Kapcsolo
                {
                    RendelesId = addRelationDto.RendelesId,
                    TermekekId = addRelationDto.TermekekId
                };

                if (relation != null)
                {
                    await _context.Kapcsolos.AddAsync(relation);
                    await _context.SaveChangesAsync();

                    _responseDto.Message = "Sikeres összerendelés.";
                    _responseDto.Result = relation;

                    return _responseDto;
                }

                _responseDto.Message = "Sikertelen összerendelés.";
                _responseDto.Result = relation;

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = ex.Data;

                return _responseDto;
            }
        }
    }
}
