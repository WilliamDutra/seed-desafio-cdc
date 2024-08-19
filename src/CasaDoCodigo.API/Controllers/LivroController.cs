using CasaDoCodigo.Aplicacao.Livro;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : Controller
    {
        private CriarLivroHandler _criarLivroHandler;

        private ObterTodosOsLivrosHandler _obterTodosOsLivrosHandler;

        public LivroController(CriarLivroHandler criarLivroHandler, ObterTodosOsLivrosHandler obterTodosOsLivrosHandler)
        {
            _criarLivroHandler = criarLivroHandler;
            _obterTodosOsLivrosHandler = obterTodosOsLivrosHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarLivroCommand command)
        {
            var resultado = _criarLivroHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult Listar(ObterTodosOsLivrosQuery queries)
        {
            var livros = _obterTodosOsLivrosHandler.Handle(queries);
            return Ok(livros);
        }

    }
}
