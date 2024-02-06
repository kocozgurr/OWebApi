using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Repository
{
    public class HaberRepository : IHaberRepository
    {
        private readonly DataContext _context;

        public HaberRepository(DataContext context)
        {
            _context = context;
        }
        public Haber GetHabers(int id)
        {
            return _context.haberler.Where(h=> h.Id == id).FirstOrDefault();
        }

        public ICollection<Haber> GetHabers()
        {
            return _context.haberler.ToList();
        }
    }
}
