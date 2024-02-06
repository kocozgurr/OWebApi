using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Interfaces
{
    public interface ITgbFirmaRepository
    {
        ICollection<TgbFirma> GetFirmas();
        TgbFirma GetTgbFirma(int id);
        TgbFirma GetFirma(string Adi);
       
        bool CreateTalep(TgbFirma  tgbFirma);

        bool Save();

    }
}
