using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Filme;
using FilmeApi.Data.Dtos.Sessao;
using FilmeApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto createSessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(sessaoDto);
            }

            return NotFound();
        }
    }
}
