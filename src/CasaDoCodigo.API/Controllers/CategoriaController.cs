using CasaDoCodigo.Aplicacao.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private CriarCategoriaHandler _criarCategoriaHandler;

        public CategoriaController(CriarCategoriaHandler criarCategoriaHandler)
        {
            _criarCategoriaHandler = criarCategoriaHandler;
        }

        [HttpPost]
        public IActionResult CriarCategoria(CriarCategoriaCommand command)
        {
            var resultado = _criarCategoriaHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok();
        }
    }
}
