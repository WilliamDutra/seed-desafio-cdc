using CasaDoCodigo.Aplicacao.Livro;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : Controller
    {
        private CriarLivroHandler _criarLivroHandler;

        public LivroController(CriarLivroHandler criarLivroHandler)
        {
            _criarLivroHandler = criarLivroHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarLivroCommand command)
        {
            var resultado = _criarLivroHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }
    }
}
