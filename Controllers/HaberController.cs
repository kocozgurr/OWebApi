using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstimTeknoparkApp.DTO;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;
using OstimTeknoparkApp.Repository;

namespace OstimTeknoparkApp.Controllers
{
    [Route("api/[controller]")]
    public class HaberController:Controller
    {
        private readonly IHaberRepository _haberRepository;
        private readonly IMapper _mapper;

        public HaberController(IHaberRepository haberRepository,IMapper mapper )
        {
            _haberRepository = haberRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Haber>))]
        public IActionResult GetHabers()
        {
            var Haber = _mapper.Map<List<RezervasyonTalebiDto>>(_haberRepository.GetHabers());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(Haber);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Haber))]

        public IActionResult GetHabers(int id)
        {
            var Haber = _mapper.Map<List<RezervasyonTalebiDto>>(_haberRepository.GetHabers(id));


            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(Haber);

        }
    }
}
