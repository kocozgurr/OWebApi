using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstimTeknoparkApp.DTO;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;
using OstimTeknoparkApp.Repository;

namespace OstimTeknoparkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToplantıSalonlarıController:Controller
    {
        private readonly IToplantıSalonRepository _toplantıSalonRepository;
        private readonly IMapper _mapper;

        public ToplantıSalonlarıController(IToplantıSalonRepository toplantıSalonRepository,IMapper mapper)
        {
            _toplantıSalonRepository = toplantıSalonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ToplantıSalon>))]
        public IActionResult GetToplantıSalons()
        {
            var ToplantıSalon = _mapper.Map<List<ToplantıSalonlarıDTO>>(_toplantıSalonRepository.GetToplantıSalons());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(ToplantıSalon);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RezervasyonTalep))]

        public IActionResult GetToplantıSalon(int id)
        {
            var ToplatıSalon = _mapper.Map<List<RezervasyonTalebiDto>>(_toplantıSalonRepository.GetToplantıSalon(id));


            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(ToplatıSalon);

        }
    }
}
