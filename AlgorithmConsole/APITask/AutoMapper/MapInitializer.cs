using APITask.Models.DTOs;
using APITask.Models.Entites;
using AutoMapper;

namespace APITask.AutoMapper
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<CountryDetail, CountryDetailDTO>().ReverseMap();
        }
    }
}