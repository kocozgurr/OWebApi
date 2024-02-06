using AutoMapper;
using OstimTeknoparkApp.DTO;
using OstimTeknoparkApp.Modals;

namespace OstimTeknoparkApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RezervasyonTalep, RezervasyonTalebiDto>();
            CreateMap<RezervasyonTalebiDto, RezervasyonTalep>();//post içinde ters halini mapladik
            CreateMap<Haber, HaberDto>();
            CreateMap<HaberDto,Haber>();
            CreateMap<ToplantıSalon,ToplantıSalonlarıDTO>();
            CreateMap<ToplantıSalonlarıDTO, ToplantıSalon>();
            CreateMap<TgbFirma, TgbFirmaDto>();
            CreateMap<TgbFirmaDto, TgbFirma>();
        }
    }
}
