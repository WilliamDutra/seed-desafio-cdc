using FluentValidation;
using System;

namespace CasaDoCodigo.Aplicacao.Cupom
{
    public class CriarCupomValidation : AbstractValidator<CriarCupomCommand>
    {
        public CriarCupomValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do cupom é obrigatório!");

            RuleFor(x => x.Valor)
                .GreaterThan(0.05M)
                .WithMessage("O valor do cupom precisa ser maior que 5%");

        }
    }
}
