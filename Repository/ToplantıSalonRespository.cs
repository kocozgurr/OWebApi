using AutoMapper;
using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Repository
{
    public class ToplantıSalonRespository : IToplantıSalonRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ToplantıSalonRespository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public ToplantıSalon GetToplantıSalon(int id)
        {
            return _context.salonlar.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<ToplantıSalon> GetToplantıSalons()
        {
            return _context.salonlar.ToList();
        }
    }
}
