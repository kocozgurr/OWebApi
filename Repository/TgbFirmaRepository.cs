using AutoMapper;
using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Repository
{
    public class TgbFirmaRepository : ITgbFirmaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TgbFirmaRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateTalep(TgbFirma tgbFirma)
        {
            _context.Add(tgbFirma);
            return Save();
        }

        public TgbFirma GetFirma(string Adi)
        {
           return _context.firmalar.Where(f => f.Adi == Adi).FirstOrDefault();
        }

        public ICollection<TgbFirma> GetFirmas()
        {
            return _context.firmalar.OrderBy(f => f.Id).ToList();
        }

        public TgbFirma GetTgbFirma(int id)
        {
            return _context.firmalar.Where(f => f.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
