using System.ComponentModel.DataAnnotations;

namespace OstimTeknoparkApp.Modals
{
    public class ToplantıSalon
    {
       
        public int Id { get; set; }
       
        public string? Adi { get; set; }
        public int? Kisi { get; set; }
        public string? Konum { get; set; }
      
        public ICollection<RezervasyonTalep> RezervasyonTaleps { get; set; }
    }
}
