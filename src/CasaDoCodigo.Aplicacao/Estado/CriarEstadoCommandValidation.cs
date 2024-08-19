using System;
using FluentValidation;

namespace CasaDoCodigo.Aplicacao.Estado
{
    public class CriarEstadoCommandValidation : AbstractValidator<CriarEstadoCommand>
    {
        public CriarEstadoCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do estado é obrigatório!");

            RuleFor(x => x.Sigla)
                .NotEmpty()
                .WithMessage("A sigla do estado é obrigatório!");

            RuleFor(x => x.PaisId)
                .NotEmpty()
                .WithMessage("O pais do estado é obrigatório!");
        }
    }
}
