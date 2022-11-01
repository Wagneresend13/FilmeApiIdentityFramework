using FilmeApi.Data;
using FilmeApi.Model;
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
        private readonly FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFlme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if(filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }
    }
}
