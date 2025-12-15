using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class RendelesService : IRendeles
    {
        private readonly DatabaseContext _context;
        private readonly ResponseDto _responseDto;

        public RendelesService(DatabaseContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;

        }

        public async Task<ResponseDto> GetAllRendeles()
        {
			try
			{
                var rendeles = await _context.Rendeles.ToListAsync();
                _responseDto.Message = "Sikeres lekerd!";
                _responseDto.Result = rendeles;
                _responseDto.Success = true;
                return _responseDto;

            }
			catch (Exception ex)
			{
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                _responseDto.Success = false;
                return _responseDto;
            }
        }

        public async Task<ResponseDto> GetAllRendelesWithCard()
        {
            try
            {
                var rendeles = await _context.Rendeles.Where(x => x.FizetesMod == "Kártya").ToListAsync();
                _responseDto.Message = "Sikeres lekerd!";
                _responseDto.Result = rendeles;
                _responseDto.Success = true;
                return _responseDto;

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                _responseDto.Success = false;
                return _responseDto;
            }
        }

        public async Task<ResponseDto> GetAllRendelesWithFood()
        {
            try
            {
                var response = await _context.Rendeles
                    .Include(x => x.Kapcsolos)
                    .ThenInclude(x => x.Termekek)
                    .ToListAsync();


                var food = response
                   .Select(x => new {
                       x.AsztalSzam,
                       Termekek = x.Kapcsolos
                   .Select(y => y.Termekek.Etel)
                   })
                   .OrderBy(x => x.AsztalSzam)
                   .GroupBy(x => x.AsztalSzam)
                .ToList();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = food;

                return _responseDto;
            }
            catch (Exception ex)
            {

                _responseDto.Message = ex.Message;
                _responseDto.Result = null;

                return _responseDto;
            }

        }
    }
}
