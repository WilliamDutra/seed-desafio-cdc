using CasaDoCodigo.Aplicacao.Compra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/pagamento")]
    [ApiController]
    public class CompraController : ControllerBase
    {

        private CriarCompraHandler _criarPagamentoHandler;

        public CompraController(CriarCompraHandler criarPagamentoHandler)
        {
            _criarPagamentoHandler = criarPagamentoHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarCompraCommand command)
        {
            var resultado = _criarPagamentoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

    }
}
