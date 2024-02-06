using AutoMapper;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MimeKit;
using MimeKit.Text;
using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Modals;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace OstimTeknoparkApp.Repository
{
    public class RezervasyonTalepRepository : IRezervasyonTalepRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public RezervasyonTalepRepository(DataContext context,IMapper mapper)
        {  
            _context = context;
            _mapper = mapper;
        }

        public bool CreateTalep(RezervasyonTalep rezervasyonTalep)
        {
            _context.Add(rezervasyonTalep);
        
            return  Save();
           
        }

        public ICollection<RezervasyonTalep> GetRezervasyonTaleps()
        {
            return _context.rezervasyonlar.OrderBy(r => r.Id).ToList(); 
            //datacontextedki tablo adı oda sqldeki tablo adı rezervasyonlar
        }

        public RezervasyonTalep GetRezervasyonTaleps(int id)
        {
            return _context.rezervasyonlar.Where(r => r.Id == id).FirstOrDefault();
        }

        public RezervasyonTalep GetRezervasyonTaleps(string Adi)
        {
            return _context.rezervasyonlar.Where(r => r.Ad == Adi).FirstOrDefault();
            // == kısmında ilk kısım modals da ne yazdogomız sonrasındaki ise ne olsun istediğimiz
        }

        public bool Save()
        {


            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
     


    }
}
