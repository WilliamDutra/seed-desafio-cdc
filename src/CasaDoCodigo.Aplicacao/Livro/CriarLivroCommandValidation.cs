using System;
using FluentValidation;

namespace CasaDoCodigo.Aplicacao.Livro
{
    public class CriarLivroCommandValidation : AbstractValidator<CriarLivroCommand>
    {
        public CriarLivroCommandValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("O titulo do livro é obrigatório!");

            RuleFor(x => x.Resumo)
                .NotEmpty()
                .WithMessage("O resumo do livro é obrigatório!");

            RuleFor(x => x.Resumo)
                .MaximumLength(500)
                .WithMessage("O máximo de caracteres do resumo são de 500!");

            RuleFor(x => x.Preco)
                .GreaterThan(20)
                .WithMessage("O preço minimo de um livro é de 20 reais!");

            RuleFor(x => x.NumeroDePaginas)
                .GreaterThan(100)
                .WithMessage("O número minimo de páginas é de 100!");

            RuleFor(x => x.DataPublicacao)
                .GreaterThan(DateTime.Now)
                .WithMessage("A data de publicação não pode ser menor que hoje!");

            RuleFor(x => x.Isbn)
                .NotEmpty()
                .WithMessage("O Isbn é obrigatório!");

            RuleFor(x => x.AutorId)
                .NotNull()
                .WithMessage("O autor é obrigatório!");

            RuleFor(x => x.CategoriaId)
                .NotNull()
                .WithMessage("A categoria é obrigatória!");
        }
    }
}
