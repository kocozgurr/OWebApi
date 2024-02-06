using Microsoft.AspNetCore.Mvc;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Interfaces
{
    public interface IRezervasyonTalepRepository
    {
        ICollection<RezervasyonTalep> GetRezervasyonTaleps();
        RezervasyonTalep GetRezervasyonTaleps(int id);
        RezervasyonTalep GetRezervasyonTaleps(string Adi);

    


        bool CreateTalep(RezervasyonTalep rezervasyonTalep);

        bool Save();


    }
}
