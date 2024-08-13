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

                var autorExistente = _autorRepositorio.ObterPorEmail(command.Email);

                if (autorExistente != null)
                    return new CommandResult(false, "e-mail duplicado no sistema!");

                var autor = Dominio.Autor.Criar(command.Nome, command.Email, command.Descricao);
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