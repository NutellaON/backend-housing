using AutoMapper;
using REST_API.Dto;
using REST_API.Models;

namespace REST_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Māja, MājaDto>();
            CreateMap<MājaDto, Māja>();
            CreateMap<Dzīvoklis, DzīvoklisDto>();
            CreateMap<DzīvoklisDto, Dzīvoklis>();
            CreateMap<Iedzīvotājs, IedzīvotājsDto>();
            CreateMap<IedzīvotājsDto, Iedzīvotājs>();
        }
    }
}
