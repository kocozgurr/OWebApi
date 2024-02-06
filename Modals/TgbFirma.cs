using System.ComponentModel.DataAnnotations;

namespace OstimTeknoparkApp.Modals
{
    public class TgbFirma
    {
        public int Id { get; set; }
        
        public string? Adi  { get; set; }
      
        public string?   Bina { get; set; }
        public string? YetkiliAd { get; set; }
        public string? YetkiliSoyad { get; set; }
        public int? Telefon { get; set; }
        public string? Eposta { get; set; }
        public string? WebSitesi  { get; set;}

        public string? Adres { get; set; }
        public string? Hakkında { get; set; }
        public int? YetkiliTC { get; set; }
        public int? Sifre { get; set; }
        public ICollection<RezervasyonTalep> RezervasyonTaleps { get; set; }
    }
}
