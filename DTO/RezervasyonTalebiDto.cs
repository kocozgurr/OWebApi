using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.DTO
{
    public class RezervasyonTalebiDto
    {
 
        public string Ad { get; set; }
        public string Saat { get; set; }
        public string Tarih { get; set; }
        public int Cay { get; set; }

        public int Kahve { get; set; }
        public string EkTalep { get; set; }

        public TgbFirmaDto TgbFirma { get; set; }
        public ToplantıSalonlarıDTO ToplantıSalon { get; set; }
    }
}
