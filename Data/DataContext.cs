using Microsoft.EntityFrameworkCore;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        public DbSet<Haber> haberler { get; set; }
        public DbSet<RezervasyonTalep> rezervasyonlar { get; set; }
        public DbSet<TgbFirma> firmalar  { get; set; }
        public DbSet<ToplantıSalon> salonlar { get; set;}


    }
}
