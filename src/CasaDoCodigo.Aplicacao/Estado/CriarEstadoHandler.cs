using CasaDoCodigo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.Aplicacao.Estado
{
    public class CriarEstadoHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarEstadoHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarEstadoCommand command)
        {
            var validator = new CriarEstadoCommandValidation();
            var validate = validator.Validate(command);

            if (!validate.IsValid)
                return new CommandResult(false, string.Join(",", validate.Errors.Select(x => x.ErrorMessage)));

            var paisEncontado = _autorRepositorio.ObterPaisPorId(command.PaisId);

            if (paisEncontado == null)
                return new CommandResult(false, "O pais dessa estado não foi encontrado!");

            var estado = Dominio.Estado.Criar(command.Nome, command.Sigla, command.PaisId);

            return new CommandResult(true, "estado criado com sucesso!");

        }

    }
}
