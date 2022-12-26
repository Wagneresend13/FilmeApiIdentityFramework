using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Filme;
using FilmeApi.Model;

namespace FilmeApi.Services
{
    public class FilmeService
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context= context; 
            _mapper= mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {

            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
           return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;

            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }

            return null;
        }

        public ReadFilmeDto AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null)
            {
                return null;
            }

            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public ReadFilmeDto DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null)
            {
                return null;
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }
    }
}
