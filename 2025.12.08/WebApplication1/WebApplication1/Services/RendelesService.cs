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

        public async Task<ResponseDto> GetRendelesTetelek()
        {
            try
            {
                var rendeles = await _context.Rendeles.ToListAsync();
                var termekek = await _context.Termekeks.ToListAsync();
                var kapcsolo = await _context.Kapcsolos.ToListAsync();
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
        public async Task<ResponseDto> GetRendelesenkentTetelek()
        {
            try
            {
                var result = await _context.Rendeles
                    .Include(r => r.Kapcsolos)
                    .ThenInclude(k => k.Termekek)
                    .Select(r => new
                    {
                        r.Id,
                        Termekek = r.Kapcsolos.Select(k => k.Termekek.Etel)
                    })
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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

        public async Task<ResponseDto> GetTermekekRendelesenkent()
        {
            try
            {
                var result = await _context.Kapcsolos
                    .Include(k => k.Termekek)
                    .Select(k => new
                    {
                        k.RendelesId,
                        TermekNev = k.Termekek.Etel
                    })
                    .Distinct()
                    .ToListAsync();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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

        public async Task<ResponseDto> GetKolasRendelesek()
        {
            try
            {
                var result = await _context.Kapcsolos
                    .Include(k => k.Termekek)
                    .Where(k => k.Termekek.Etel == "Kóla")
                    .Select(k => k.RendelesId)
                    .Distinct()
                    .ToListAsync();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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
        public async Task<ResponseDto> GetRendelesekTetelszama()
        {
            try
            {
                var result = await _context.Kapcsolos
                    .GroupBy(x => x.RendelesId)
                    .Select(g => new
                    {
                        RendelesId = g.Key,
                        Tetelszam = g.Count()
                    })
                    .ToListAsync();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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
        public async Task<ResponseDto> GetKettesRendelesOsszertek()
        {
            try
            {
                var osszeg = await _context.Kapcsolos
                    .Where(x => x.RendelesId == 2)
                    .Include(x => x.Termekek)
                    .SumAsync(x => x.Termekek.Ar);

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = new
                {
                    RendelesId = 2,
                    OsszErtek = osszeg
                };
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
        public async Task<ResponseDto> GetRendelesekOsszerteke()
        {
            try
            {
                var result = await _context.Kapcsolos
                    .Include(x => x.Termekek)
                    .GroupBy(x => x.RendelesId)
                    .Select(g => new
                    {
                        RendelesId = g.Key,
                        OsszErtek = g.Sum(x => x.Termekek.Ar)
                    })
                    .ToListAsync();

                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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
        public async Task<ResponseDto> GetLegdragabbRendeles()
        {
            try
            {
                    var result = await _context.Kapcsolos
                     .Include(x => x.Termekek)
                     .GroupBy(x => x.RendelesId)
                     .Select(g => new
                     {
                         RendelesId = g.Key,
                         OsszErtek = g.Sum(x => x.Termekek.Ar)
                     })
                     .OrderByDescending(x => x.OsszErtek)
                     .FirstOrDefaultAsync();


                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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

        public async Task<ResponseDto> GetAsztalokHanyszorRendeltek()
        {
            try
            {
                var result = await _context.Rendeles
                 .GroupBy(x => x.AsztalSzam)
                 .Select(g => new 
                 {
                     Id = g.Key,
                     Rendelesekszama = g.Count()
                 }).ToListAsync();


                _responseDto.Message = "Sikeres lekérdezés";
                _responseDto.Result = result;
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
