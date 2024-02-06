using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Interfaces
{
    public interface IToplantıSalonRepository
    {
        ICollection<ToplantıSalon> GetToplantıSalons();
        ToplantıSalon GetToplantıSalon(int id);


    }
}
