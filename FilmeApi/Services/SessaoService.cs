using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Endereco;
using FilmeApi.Data.Dtos.Sessao;
using FilmeApi.Model;
using System;

namespace FilmeApi.Services
{
    public class SessaoService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto SessaooDto = _mapper.Map<ReadSessaoDto>(sessao);

                return SessaooDto;
            }

            return null;
        }
    }
}
