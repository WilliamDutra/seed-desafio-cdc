using System;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Pais
{
    public class CriarPaisHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarPaisHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarPaisCommand command)
        {
            var validator = new CriarPaisCommandValidation();
            var validate = validator.Validate(command);

            if (!validate.IsValid)
                return new CommandResult(false, string.Join(",", validate.Errors.Select(x => x.ErrorMessage)));

            var paisComMesmoNome = _autorRepositorio.ObterPaisPorNome(command.Nome);

            if (paisComMesmoNome != null)
                return new CommandResult(false, "Já existe um país com o mesmo nome no sistema!");

            var pais = Dominio.Pais.Criar(command.Nome, command.Sigla);

            _autorRepositorio.Salvar(pais);

            return new CommandResult(true, "pais cadastrado com sucesso!");
        }

    }
}
