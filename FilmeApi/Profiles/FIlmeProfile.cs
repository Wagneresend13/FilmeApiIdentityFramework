using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Model;

namespace FilmeApi.Profiles
{
    public class FIlmeProfile : Profile
    {
        public FIlmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();

        }
    }
}
