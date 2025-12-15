using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KapcsoloController : ControllerBase
    {
        private readonly IKapcsolo _service;

        public KapcsoloController(IKapcsolo service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> PostRelation(AddRelationDto addRelationDto)
        {
            var requestResult = await _service.PostNewRelation(addRelationDto) as ResponseDto;
            var result = requestResult.Result as AddRelationDto;

            if (requestResult.Result != null)
            {
                return Ok(result);
            }
            else if (requestResult.Result == null)
            {
                return NotFound(requestResult);
            }
            else
            {
                return BadRequest(requestResult);
            }


        }
    }
}
