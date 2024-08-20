using System;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Cupom
{
    public class CriarCupomHandler 
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarCupomHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarCupomCommand command)
        {
            var validator = new CriarCupomValidation();
            var validate = validator.Validate(command);

            if (!validate.IsValid)
                return new CommandResult(false, string.Join(", ", validate.Errors.Select(x => x.ErrorMessage)));

            var cupom = Dominio.Cupom.Criar(command.Nome, command.Valor, command.Validade);

            _autorRepositorio.Salvar(cupom);

            return new CommandResult(true, "cupom criado com sucesso!");
        }

    }
}
