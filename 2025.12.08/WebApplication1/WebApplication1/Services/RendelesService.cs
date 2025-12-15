using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class RendelesService : IRendeles
    {
		private readonly DatabaseContext _context;
        ResponseDto _responseDto = new ResponseDto();

        public RendelesService(DatabaseContext context)
        {
            _context = context;
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
                //var rendeles = await _context.Rendeles.Include(x => x.Kapcsolos).ThenInclude(x => x.Rendeles.Id,).ToListAsync();
                _responseDto.Message = "Sikeres lekerd!";
                _responseDto.Result = null;
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
    }
}
