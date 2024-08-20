using CasaDoCodigo.Aplicacao.Cupom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/cupom")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private CriarCupomHandler _criarCupomHandler;

        public CupomController(CriarCupomHandler criarCupomHandler)
        {
            _criarCupomHandler = criarCupomHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarCupomCommand command)
        {
            var resultado = _criarCupomHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }
    }
}
