using AutoMapper;
using timetable.Models;
using timetable.Resources;

namespace timetable.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Deget, DegetResource>();
            CreateMap<Disponibel, DisponibelResource>();
            CreateMap<Ditet, DitetResource>();
            CreateMap<ImportLendet, ImportLendetResource>();
            CreateMap<Klasat, KlasatResource>();
            CreateMap<Lendet, LendetResource>();
            CreateMap<Orari, OrariResource>();
            CreateMap<Oret, OretResource>();
            CreateMap<Tipet, TipetResource>();
        }
    }
}