using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Filme;
using FilmeApi.Data.Dtos.Sessao;
using FilmeApi.Model;
using FilmeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto createSessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(createSessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessaoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }
    }
}
