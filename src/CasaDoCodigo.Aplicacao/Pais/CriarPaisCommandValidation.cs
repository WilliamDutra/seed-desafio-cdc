using System;
using FluentValidation;

namespace CasaDoCodigo.Aplicacao.Pais
{
    public class CriarPaisCommandValidation : AbstractValidator<CriarPaisCommand>
    {
        public CriarPaisCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do país é obrigatório!");

            RuleFor(x => x.Sigla)
                .NotEmpty()
                .WithMessage("A sigla do país é obrigatório!");
        }
    }
}
