using System.ComponentModel.DataAnnotations;

namespace OstimTeknoparkApp.Modals
{
    public class Haber
    {
        public int Id { get; set; }
      
        public string? Başlık { get; set; }
        public string? Açıklama { get; set; }
        public byte[]? Resim { get; set; }
        public byte[]? Slider { get; set; }
    }
    
}
