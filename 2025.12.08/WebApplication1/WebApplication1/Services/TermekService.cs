using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class TermekService : ITermekek
    {
		private readonly DatabaseContext _context;
        ResponseDto _responseDto = new ResponseDto();

        public TermekService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> GetAllTermek()
        {
			try
			{
                var termek = await _context.Termekeks.ToListAsync();
                _responseDto.Message = "Sikeres lekerd!";
                _responseDto.Result = termek;
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
