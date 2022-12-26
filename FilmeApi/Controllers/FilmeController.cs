using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos.Filme;
using FilmeApi.Model;
using FilmeApi.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;


        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;    
        }

        [HttpPost]
        public IActionResult AdicionaFlme([FromBody] CreateFilmeDto filmeDto)
        {
           ReadFilmeDto readDto =  _filmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
           List<ReadFilmeDto> readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
           ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorId(id);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto) 
        {
            ReadFilmeDto readDto = _filmeService.AtualizaFilme(id, filmeDto);

            if (readDto != null) return Ok(readDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            ReadFilmeDto readDto = _filmeService.DeleteFilme(id);

            if (readDto != null) return Ok(readDto);

            return NoContent();
        }
    }
}
