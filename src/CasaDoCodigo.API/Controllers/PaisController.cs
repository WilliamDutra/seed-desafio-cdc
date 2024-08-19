using CasaDoCodigo.Aplicacao.Estado;
using CasaDoCodigo.Aplicacao.Pais;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [ApiController]
    [Route("api/pais")]
    public class PaisController : Controller
    {

        private CriarPaisHandler _criarPaisHandler;

        private CriarEstadoHandler _criarEstadoHandler;

        public PaisController(CriarPaisHandler criarPaisHandler, CriarEstadoHandler criarEstadoHandler)
        {
            _criarPaisHandler = criarPaisHandler;
            _criarEstadoHandler = criarEstadoHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarPaisCommand command)
        {
            var resultado = _criarPaisHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("estado")]
        public IActionResult CriarEstado(CriarEstadoCommand command)
        {
            var resultado = _criarEstadoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }
    }
}
