using System.ComponentModel.DataAnnotations;

namespace OstimTeknoparkApp.Modals
{
    public class RezervasyonTalep
    {
        public int Id { get; set; }
        [Required]

        public int? TgbFirmaId { get; set; }
        public string Ad { get; set; }
        public string Saat { get; set; }
        public string Tarih { get; set; }
        public int Cay { get; set; }

        public int Kahve { get; set; }
        public string EkTalep { get; set; }

     
        public TgbFirma TgbFirma { get; set; }
        public ToplantıSalon ToplantıSalon { get; set; }


    }
}
