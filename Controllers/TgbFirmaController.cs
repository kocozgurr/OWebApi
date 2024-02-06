using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.DTO;
using OstimTeknoparkApp.Modals;
using OstimTeknoparkApp.Repository;
using OstimTeknoparkApp.Interfaces;

namespace OstimTeknoparkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TgbFirmaController : Controller
    {

        private readonly ITgbFirmaRepository _tgbFirmaRepository;
        private readonly IMapper _mapper;

        public TgbFirmaController(ITgbFirmaRepository tgbFirmaRepository, IMapper mapper)
        {

            _tgbFirmaRepository = tgbFirmaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TgbFirma>))]
        public IActionResult GetFirmas()
        {
            var Fİrma = _mapper.Map<List<TgbFirmaDto>>(_tgbFirmaRepository.GetFirmas());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(Fİrma);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateTalep([FromBody] TgbFirmaDto FirmaCreate)
        {
            if (FirmaCreate == null)
            {
                return BadRequest("Invalid request data"); // JSON verisi boşsa 400 Bad Request döndürün
            }

            var Firma = _tgbFirmaRepository.GetFirmas()
                .FirstOrDefault(r => r.Adi != null && r.Adi.Trim().ToUpper() == FirmaCreate.Adi.Trim().ToUpper());

            if (Firma != null)
            {
                return UnprocessableEntity("A reservation with the same name already exists"); // 422 Unprocessable Entity döndürün
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Model geçerlilik kurallarına uymuyorsa 400 Bad Request döndürün
            }

            var FirmaMap = _mapper.Map<TgbFirma>(FirmaCreate);

            if (!_tgbFirmaRepository.CreateTalep(FirmaMap))
            {
                return StatusCode(500, "Failed to create reservation request"); // 500 Internal Server Error döndürün
            }

            return NoContent(); // HTTP 204 No Content
        }
    }
}
