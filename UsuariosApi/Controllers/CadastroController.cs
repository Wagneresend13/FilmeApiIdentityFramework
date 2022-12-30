using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpGet]
        public IActionResult CadastraUsuario(CreateUsuarioDto usuarioDto) 
        {

            return Ok();
        }
    }
}
