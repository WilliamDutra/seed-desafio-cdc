using CasaDoCodigo.Dominio;
using System;

namespace CasaDoCodigo.Aplicacao.Livro
{
    public class CriarLivroHandler
    {
        private IAutorRepositorio _autorRepositorio;

        public CriarLivroHandler(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public CommandResult Handle(CriarLivroCommand command)
        {
            var validator = new CriarLivroCommandValidation();
            var validate = validator.Validate(command);

            if (!validate.IsValid)
                return new CommandResult(false, string.Join(",", validate.Errors));


            var livroFoiEncontradoComMesmoNome = _autorRepositorio.ObterLivroPorNome(command.Titulo).Count() > 1 ? true : false;

            if (livroFoiEncontradoComMesmoNome)
                return new CommandResult(false, "Já existe um livro com esse mesmo nome!");

            var novoLivro = Dominio.Livro.Criar(command.Isbn, command.Titulo, command.Resumo, command.Sumario, command.Preco, command.NumeroDePaginas, command.DataPublicacao, command.CategoriaId, command.AutorId);

            _autorRepositorio.Salvar(novoLivro);

            return new CommandResult(true, "O livro foi cadastrado com sucesso!");
        }

    }
}
