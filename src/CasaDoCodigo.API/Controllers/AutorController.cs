using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Aplicacao.Autor;

namespace CasaDoCodigo.API.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private CriarNovoAutorHandler _criarNovoAutorHandler;

        public AutorController(CriarNovoAutorHandler criarNovoAutorHandler)
        {
            _criarNovoAutorHandler = criarNovoAutorHandler;
        }

        [HttpPost]
        public IActionResult CriarAutor(CriarNovoAutorCommand command)
        {
            var resultado = _criarNovoAutorHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok();
        }

    }
}
