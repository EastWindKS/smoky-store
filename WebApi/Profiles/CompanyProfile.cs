using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyReadDto>();
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();
            CreateMap<Strength, StrAddDto>();
            CreateMap<StrAddDto, Strength>();
        }
    }
}