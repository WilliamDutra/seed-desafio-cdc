using System;
using FluentValidation;
using CasaDoCodigo.Aplicacao.Cupom;

namespace CasaDoCodigo.Aplicacao.Categoria
{
    public class CriarCategoriaCommandValidation : AbstractValidator<CriarCategoriaCommand>
    {
        public CriarCategoriaCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da categoria é obrigatório!");
        }
    }
}
