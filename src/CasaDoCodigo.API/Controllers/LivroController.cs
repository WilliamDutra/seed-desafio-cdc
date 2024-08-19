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

        private ObterLivroPorIdHandler _obterLivroPorIdHandler;

        public LivroController(CriarLivroHandler criarLivroHandler, ObterTodosOsLivrosHandler obterTodosOsLivrosHandler, ObterLivroPorIdHandler obterLivroPorIdHandler)
        {
            _criarLivroHandler = criarLivroHandler;
            _obterTodosOsLivrosHandler = obterTodosOsLivrosHandler;
            _obterLivroPorIdHandler = obterLivroPorIdHandler;
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


        [HttpGet]
        [Route("{id}")]
        public IActionResult ListarPorId(Guid id)
        {
            var queries = new ObterLivroPorIdQuery { Id = id };
            var livros = _obterLivroPorIdHandler.Handle(queries);
            if (livros == null)
                return Forbid();
            return Ok(livros);
        }

    }
}
