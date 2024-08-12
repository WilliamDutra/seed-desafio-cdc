using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Autor
{
    public class CriarNovoAutorHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarNovoAutorHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;   
        }

        public CommandResult Handle(CriarNovoAutorCommand command)
        {

            try
            {
                var validation = new CriarNovoAutorCommandValidation();
                var erros = validation.Validate(command);

                if (!erros.IsValid)
                    return new CommandResult(false, string.Join(",", erros.Errors.Select(x=> x.ErrorMessage)));

                var autor = new Dominio.Autor(command.Nome, command.Email, command.Descricao);
                _autorRepositorio.Salvar(autor);

                return new CommandResult(true, "autor criado com sucesso!");
            }
            catch (Exception)
            {

                return new CommandResult(false, "houve um erro ao criar o autor!");
            }
        }

    }
}