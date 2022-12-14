using AutoMapper;
using FilmeApi.Data.Dtos.Gerente;
using FilmeApi.Model;

namespace FilmeApi.Profiles
{
    public class GerenteProfile : Profile
    {

        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
        }
    }
}
