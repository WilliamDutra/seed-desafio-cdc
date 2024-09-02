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

        private ObterCompraHandler _obterCompraHandler;

        public CompraController(CriarCompraHandler criarPagamentoHandler, ObterCompraHandler obterCompraHandler)
        {
            _criarPagamentoHandler = criarPagamentoHandler;
            _obterCompraHandler = obterCompraHandler;
        }

        [HttpPost]
        public IActionResult Criar(CriarCompraCommand command)
        {
            var resultado = _criarPagamentoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterCompraPorId(Guid id)
        {
            var obterCompraCommand = new ObterCompraCommand { Id = id };
            var resultado = _obterCompraHandler.Handle(obterCompraCommand);
            return Ok(resultado);
        }

    }
}
