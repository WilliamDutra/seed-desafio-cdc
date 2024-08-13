using System;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Categoria
{
    public class CriarCategoriaHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarCategoriaHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarCategoriaCommand command)
        {
            var validation = new CriarCategoriaCommandValidation();
            var erros = validation.Validate(command);

            if (!erros.IsValid)
                return new CommandResult(false, string.Join(",", erros.Errors.Select(x => x.ErrorMessage)));

            var categoriaExistente = _autorRepositorio.ObterCategoriaPorNome(command.Nome);

            if (categoriaExistente != null)
                return new CommandResult(false, "Essa categoria já existe no sistema!");


            var categoria = Dominio.Categoria.Criar(command.Nome, command.Descricao);
            _autorRepositorio.Salvar(categoria);

            return new CommandResult(true, "categoria cria com sucesso!");
        }

    }
}
