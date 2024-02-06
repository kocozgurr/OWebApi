
using AutoMapper;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using OstimTeknoparkApp.DTO;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;
using System.Reflection.Metadata.Ecma335;
using MailKit.Net.Smtp;

namespace OstimTeknoparkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonTalepController : Controller
    {
        private readonly IRezervasyonTalepRepository _rezervasyonTalepRepository;
        private readonly IMapper _mapper;

        public RezervasyonTalepController(IRezervasyonTalepRepository rezervasyonTalepRepository,IMapper mapper)
        {
            _rezervasyonTalepRepository = rezervasyonTalepRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RezervasyonTalep>))]
        public IActionResult GetRezervasyonTaleps()
        {
            var RezervasyonTaleps = _mapper.Map<List<RezervasyonTalebiDto>>(_rezervasyonTalepRepository.GetRezervasyonTaleps());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(RezervasyonTaleps);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RezervasyonTalep))]
    
       public IActionResult GetRezervasyonTaleps(int id)
        {
            var RezervasyonTaleps =_mapper.Map<List<RezervasyonTalebiDto>>( _rezervasyonTalepRepository.GetRezervasyonTaleps(id));


            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(RezervasyonTaleps);

        }

        [HttpGet("{Adi}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RezervasyonTalep>))]

        public IActionResult GetRezervasyonTaleps(string Adi)
        {
            var RezervasyonTaleps = _mapper.Map<List<RezervasyonTalebiDto>>(_rezervasyonTalepRepository.GetRezervasyonTaleps());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(RezervasyonTaleps);

        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateTalep([FromBody] RezervasyonTalebiDto TalepCreate)
        {
            if (TalepCreate == null)
                return BadRequest(ModelState);

            var Rezervasyon = _rezervasyonTalepRepository.GetRezervasyonTaleps()
                .Where(r => r.Ad.Trim().ToUpper() == TalepCreate.Ad.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (Rezervasyon != null)
            {
                ModelState.AddModelError("", "A reservation with the same name already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var TalepMap = _mapper.Map<RezervasyonTalep>(TalepCreate);

            if (!_rezervasyonTalepRepository.CreateTalep(TalepMap))
            {
                ModelState.AddModelError("", "Failed to create reservation request");
                return StatusCode(500, ModelState);
            }
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("kocozgurr1@gmail.com"));
            email.To.Add(MailboxAddress.Parse("ozgur.koc@ostimteknopark.com.tr"));
            email.Subject = "Rezervasyon İsteği Oluşturuldu";
            email.Body = new TextPart(TextFormat.Html) { Text = "Rezervasyon isteği oluşturuldu: " + TalepCreate.Ad };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("kocozgurr1@gmail.com", "jtxelmrvuhnbrnqk");
            smtp.Send(email);
            smtp.Disconnect(true);

            return NoContent(); // HTTP 204 (No Content)
        }
    }
}
