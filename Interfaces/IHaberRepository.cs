using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Interfaces
{
    public interface IHaberRepository
    {
        ICollection<Haber> GetHabers();
        Haber GetHabers(int id);

    }
}
