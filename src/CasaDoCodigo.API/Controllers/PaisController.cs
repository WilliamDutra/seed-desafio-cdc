using CasaDoCodigo.Aplicacao.Pais;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [ApiController]
    [Route("api/pais")]
    public class PaisController : Controller
    {

        private CriarPaisHandler _criarPaisHandler;

        public PaisController(CriarPaisHandler criarPaisHandler)
        {
            _criarPaisHandler = criarPaisHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarPaisCommand command)
        {
            var resultado = _criarPaisHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }
    }
}
