using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Sessao;
using FilmeApi.Model;

namespace FilmeApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
            .ForMember(dto => dto.HorarioDeInicio, opts => opts
            .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
        }
    }
}
